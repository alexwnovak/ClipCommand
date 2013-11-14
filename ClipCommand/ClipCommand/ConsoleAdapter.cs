using System;
using System.IO;

namespace ClipCommand
{
   public class ConsoleAdapter : IConsoleAdapter
   {
      public Stream OpenStandardInput()
      {
         return Console.OpenStandardInput();
      }
   }
}
