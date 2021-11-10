namespace TicTacToe.ReactWebApp
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Timers;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using TicTacToe.Core.Interfaces;

    public class GameEngineFactory : IGameEngineFactory, IDisposable
    {
        private const string Key = "TicTacToe.ReactWebApp.EngineId";

        private readonly IHttpContextAccessor accessor;

        private readonly Dictionary<string, IGameEngine> engines = new();

        private readonly Dictionary<string, bool> enginesLastRetrieved = new();

        private readonly double Interval = TimeSpan.FromMinutes(IdleTimeout.Default.TotalMinutes * 2).TotalMilliseconds;

        private readonly ILogger<GameEngineFactory> logger;

        private readonly IServiceProvider serviceProvider;

        private readonly Timer timer;

        public GameEngineFactory(ILogger<GameEngineFactory> logger, IHttpContextAccessor accessor,
                                 IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.accessor = accessor;
            this.serviceProvider = serviceProvider;

            timer = new Timer(Interval);
            timer.Elapsed += Elapsed;
            timer.Start();
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public IGameEngine GetEngine()
        {
            HttpContext context = accessor?.HttpContext;
            if (context == null)
            {
                throw new Exception("Unable to continue, there is no http context.");
            }

            string id = context.Session.GetString(Key);

            IGameEngine engine;

            if (!string.IsNullOrEmpty(id) && engines.ContainsKey(id))
            {
                logger.LogDebug("Returning existing game engine.");
                engine = engines[id];
            }
            else
            {
                logger.LogDebug("Creating a new game engine");
                engine = serviceProvider.GetRequiredService<IGameEngine>();
                id = engine.Id;
                engines.Add(id, engine);
                context.Session.SetString(Key, id);
            }

            enginesLastRetrieved[id] = true;

            return engine;
        }

        private void Elapsed(object sender, ElapsedEventArgs e)
        {
            var enginesToRemove = new List<string>();

            Parallel.ForEach(enginesLastRetrieved, keyPair =>
            {
                bool recentlyRetrieved = keyPair.Value;
                if (recentlyRetrieved)
                {
                    return;
                }

                enginesToRemove.Add(keyPair.Key);
            });

            foreach (KeyValuePair<string, bool> keyPair in enginesLastRetrieved)
            {
                string key = keyPair.Key;
                if (enginesToRemove.Contains(key))
                {
                    engines.Remove(key);
                    enginesLastRetrieved.Remove(key);
                }
                else
                {
                    enginesLastRetrieved[key] = false;
                }
            }
        }
    }
}