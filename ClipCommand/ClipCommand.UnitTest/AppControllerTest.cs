using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClipCommand.UnitTest
{
   [TestClass]
   public class AppControllerTest
   {
      [TestMethod]
      public void Run_NoArguments_ReturnsExitCodeZero()
      {
         var appController = new AppController();

         int exitCode = appController.Run( null );

         Assert.AreEqual( 0, exitCode );
      }
   }
}
