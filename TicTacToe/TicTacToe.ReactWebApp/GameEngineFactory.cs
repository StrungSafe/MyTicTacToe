namespace TicTacToe.ReactWebApp
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Timers;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    using TicTacToe.Core;
    using TicTacToe.Core.Interfaces;

    public class GameEngineFactory : IGameEngineFactory, IDisposable
    {
        private const string Key = "TicTacToe.ReactWebApp.GameEngineFactory.EngineId";

        private readonly IHttpContextAccessor accessor;

        private readonly Dictionary<string, IGameEngine> engines = new Dictionary<string, IGameEngine>();

        private readonly Dictionary<string, bool> enginesLastRetrieved = new Dictionary<string, bool>();

        private readonly double Interval = TimeSpan.FromMinutes(IdleTimeout.Default.TotalMinutes * 2).TotalMilliseconds;

        private readonly ILogger<GameEngineFactory> logger;

        private readonly Timer timer;

        public GameEngineFactory(ILogger<GameEngineFactory> logger, IHttpContextAccessor accessor)
        {
            this.logger = logger;
            this.accessor = accessor;

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
            string id = accessor.HttpContext.Session.GetString(Key);

            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
                accessor.HttpContext.Session.SetString(Key, id);
            }

            IGameEngine engine;

            if (engines.ContainsKey(id))
            {
                logger.LogDebug("Returning existing game engine.");
                engine = engines[id];
            }
            else
            {
                logger.LogDebug("Creating a new game engine");
                engine = new GameEngine(new GameBoard(new ReactGameSettings()), new MoveValidator(),
                    new GameBoardAnalyzer());
                engines.Add(id, engine);
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