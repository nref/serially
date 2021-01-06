using Serially.Core;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Serially.App
{
  public class Program
  {
    private static void PrintHelp()
    {
      var sb = new StringBuilder();
      sb.AppendLine("Serially: A REPL and tail for Serial Ports")
        .AppendLine()
        .AppendLine("Format: ")
        .AppendLine("  serially [action] [port]")
        .AppendLine()
        .AppendLine("[action]")
        .AppendLine("  help: Show this message and exit")
        .AppendLine("  tail: Tail the given port")
        .AppendLine("  repl [default]: Open a CLI with the given port")
        .AppendLine()
        .AppendLine("[port]")
        .AppendLine("  A Windows COM port, e.g. COM1")
        .AppendLine()
        .AppendLine("Examples:")
        .AppendLine("  Open a REPL on COM1: serially COM1")
        .AppendLine("           Equivalent: serially repl COM1")
        .AppendLine("       Just tail COM2: serially tail COM2");

      Console.WriteLine(sb);
    }

    private static void PrintError(string[] args)
    {
      Console.WriteLine($"Invalid arguments \"{string.Join(' ', args)}\"");
    }

    public static async Task Main(string[] args)
    {
      if (args.Length == 0)
      {
        PrintHelp();
        return;
      }

      var config = new SerialConfig();
      if (args.Length == 1)
      {
        config.PortName = args[0];
        await new Repl(config).Run();
        return;
      }

      if (args.Length > 1)
      {
        bool tail = args[0] == "tail";
        bool repl = args[0] == "repl";
        bool help = args[0] == "help";
        config.PortName = args[1];

        if (tail)
        {
          await new Repl(config).Tail();
          return;
        }

        if (repl)
        {
          await new Repl(config).Run();
          return;
        }

        if (!help)
        {
          PrintError(args);
        }

        PrintHelp();
      }
    }
  }
}
