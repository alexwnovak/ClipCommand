namespace ClipCommand
{
   public class AppController
   {
      public int Run( string[] arguments )
      {
         var inputStream = Dependency.Resolve<IInputStream>();

         inputStream.GetInput();

         return 0;
      }
   }
}
