namespace ClipCommand
{
   public class AppController
   {
      public int Run( string[] arguments )
      {
         var inputStream = Dependency.Resolve<IInputStream>();

         var data = inputStream.GetInput();

         var clipboard = Dependency.Resolve<IClipboard>();

         clipboard.Write( data );

         return 0;
      }
   }
}
