using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace Serially.RemoteApp
{
  class Program
  {
    static async Task<int> Main(string[] args)
    {
      var pipe = new NamedPipeClientStream(".", "RemoteReplService", PipeDirection.InOut, PipeOptions.None);
      using var reader = new StreamWriter(pipe);

      try
      {
        await pipe.ConnectAsync(5000);
        if (pipe.IsConnected)
        {
          await reader.WriteLineAsync(string.Join(" ", args));
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return -1;
      }

      return 0;
    }
  }
}
