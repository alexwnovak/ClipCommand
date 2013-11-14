using System.IO;

namespace ClipCommand
{
   public interface IConsoleAdapter
   {
      Stream OpenStandardInput();
   }
}
