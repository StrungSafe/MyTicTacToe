namespace TicTacToe.Console.CastleWindsor
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Core;
    using TicTacToe.Core;
    using TicTacToe.Core.Interfaces;

    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IConsoleOutput>().ImplementedBy<ConsoleOutput>(),
                Component.For<IConsoleInput>().ImplementedBy<ConsoleInput>(),
                Component.For<IGameSettings>().ImplementedBy<GameSettings>(),
                Component.For<ITicTacToeConsoleService>().ImplementedBy<TicTacToeConsoleProvider>()
            );

            container.Register(
                Component.For<IGameBoard>().ImplementedBy<GameBoard>(),
                Component.For<IGameBoardAnalyzer>().ImplementedBy<GameBoardAnalyzer>(),
                Component.For<IMoveValidator>().ImplementedBy<MoveValidator>(),
                Component.For<IGameEngine>().ImplementedBy<GameEngine>()
            );
        }
    }
}