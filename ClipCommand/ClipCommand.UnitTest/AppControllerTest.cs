using System;
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
      public void Run_EmptyArguments_ReadsInputAndWritesToClipboard()
      {
         var data = new byte[0];

         // Setup

         var inputStreamMock = new Mock<IInputStream>();
         inputStreamMock.Setup( ism => ism.GetInput() ).Returns( data );
         Dependency.RegisterInstance( inputStreamMock.Object );

         var clipboardMock = new Mock<IClipboard>();
         Dependency.RegisterInstance( clipboardMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( new string[0] );

         // Assert

         inputStreamMock.Verify( ism => ism.GetInput(), Times.Once() );
         clipboardMock.Verify( cm => cm.Write( data ), Times.Once() );
      }
   }
}
