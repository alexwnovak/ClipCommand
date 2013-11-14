namespace ClipCommand
{
   internal static class Program
   {
      private static void InitDependencyInjection()
      {
         Dependency.CreateUnityContainer();
         Dependency.RegisterType<IInputStream, InputStream>();
         Dependency.RegisterType<IClipboard, ClipboardAdapter>();
         Dependency.RegisterType<IConsoleAdapter, ConsoleAdapter>();
      }

      private static int Main( string[] arguments )
      {
         InitDependencyInjection();

         return new AppController().Run( arguments );
      }
   }
}
