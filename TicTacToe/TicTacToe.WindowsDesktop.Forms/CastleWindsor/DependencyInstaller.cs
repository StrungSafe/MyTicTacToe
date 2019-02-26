namespace TicTacToe.WindowsDesktop.Forms.CastleWindsor
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Core;
    using Core.Interfaces;

    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IGameSettings>().ImplementedBy<FormsGameSettings>()
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