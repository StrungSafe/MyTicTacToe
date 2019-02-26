namespace TicTacToe.WindowsDesktop.Forms.CastleWindsor
{
    using System;
    using System.IO;
    using System.Reflection;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor.Installer;

    internal static class DependencyRegistration
    {
        private static string AssemblyDirectory => Assembly.GetExecutingAssembly().GetCodebaseDirectory();

        internal static void Register()
        {
            WindsorContainer.Instance.Install(FromAssembly.InDirectory(new AssemblyFilter(AssemblyDirectory)));
        }

        private static string GetCodebaseDirectory(this Assembly assembly)
        {
            string path = GetCodebaseFilename(assembly);
            return Path.GetDirectoryName(path);
        }

        private static string GetCodebaseFilename(this Assembly assembly)
        {
            string codeBase = assembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            return Uri.UnescapeDataString(uri.Path);
        }
    }
}