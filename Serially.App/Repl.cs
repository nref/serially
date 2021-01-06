using Serially.Core;
using System;
using System.Threading.Tasks;

namespace Serially.App
{
  /// <summary>
  /// Read-Eval-Print loop using Console.Write and Console.ReadKey
  /// </summary>
  public class Repl
  {
    private readonly SerialConfig _config = default;
    private readonly SerialPort _port = default;

    public Repl(SerialConfig config)
    {
      _config = config;
      _port = new SerialPort();
    }

    /// <summary>
    /// Print received data. Do not send console input.
    /// </summary>
    public async Task Tail() => await Run(true);

    /// <summary>
    /// Print received data and send console input.
    /// </summary>
    public async Task Run() => await Run(false);

    private async Task Run(bool tailOnly)
    {
      try
      {
        await OpenPortAsync();

        do
        {
          LoopOnce(tailOnly);

        } while (_port.IsOpen);
      }
      finally
      {
        _port?.Close();
      }
    }

    private void LoopOnce(bool tailOnly)
    {
      Console.Write(_port.ReadExisting());

      if (tailOnly)
      {
        return;
      }

      if (!Console.KeyAvailable)
      {
        return;
      }
      ConsoleKeyInfo info = Console.ReadKey(true);

      foreach (char c in Ascii.Map(info))
      {
        _port.WriteChar(c);
      }
    }

    private async Task<SerialPort> OpenPortAsync()
    {
      Console.WriteLine($"Waiting for {_config.PortName} ...");

      while (!await TryOpen())
      {
        await Task.Delay(1000);
      }
      Console.WriteLine($"Opened {_port.PortName}");

      return _port;
    }

    private async Task<bool> TryOpen()
    {
      try
      {
        await _port.Open(_config);
      }
      catch
      {
      }

      return _port.IsOpen;
    }
  }
}
