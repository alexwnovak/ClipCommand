namespace ClipCommand
{
   public class AppController
   {
      public int Run( string[] arguments )
      {
         var consoleAdapter = Dependency.Resolve<IConsoleAdapter>();

         if ( !consoleAdapter.IsInputRedirected )
         {
            return 1;
         }

         var inputStream = Dependency.Resolve<IInputStream>();

         var data = inputStream.GetInput();

         var clipboard = Dependency.Resolve<IClipboard>();

         clipboard.Write( data );

         return 0;
      }
   }
}
