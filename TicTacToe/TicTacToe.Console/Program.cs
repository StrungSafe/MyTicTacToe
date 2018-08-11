namespace TicTacToe.Console
{
    using System;
    using CastleWindsor;
    using Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            ITicTacToeConsoleService service = null;

            try
            {
                DependencyRegistration.Register();
                service = WindsorContainer.Instance.Resolve<ITicTacToeConsoleService>();
                service.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                WindsorContainer.Instance.Release(service);
                WindsorContainer.Dispose();
                Console.WriteLine(new string('-', 100));
                Console.WriteLine();
                Console.WriteLine("Press <enter> to exit");
                Console.ReadLine();
            }
        }
    }
}