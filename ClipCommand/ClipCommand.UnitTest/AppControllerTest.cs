using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClipCommand.UnitTest
{
   [TestClass]
   public class AppControllerTest
   {
      [TestInitialize]
      public void Initialize()
      {
         Dependency.CreateUnityContainer();
      }

      [TestMethod]
      public void Run_NoArguments_ReturnsExitCodeZero()
      {
         // Setup

         var inputStreamMock = new Mock<IInputStream>();
         Dependency.RegisterInstance( inputStreamMock.Object );

         // Test

         var appController = new AppController();

         int exitCode = appController.Run( null );

         Assert.AreEqual( 0, exitCode ); 
      }

      [TestMethod]
      public void Run_NullArguments_CallsInputStream()
      {
         // Setup

         var inputStreamMock = new Mock<IInputStream>();
         Dependency.RegisterInstance( inputStreamMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( null );

         // Assert

         inputStreamMock.Verify( ism => ism.GetInput(), Times.Once() );
      }

      [TestMethod]
      public void Run_EmptyArguments_CallsInputStream()
      {
         // Setup

         var inputStreamMock = new Mock<IInputStream>();
         Dependency.RegisterInstance( inputStreamMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( new string[0] );

         // Assert

         inputStreamMock.Verify( ism => ism.GetInput(), Times.Once() );
      }
   }
}
