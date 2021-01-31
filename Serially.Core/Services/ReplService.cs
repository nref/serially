using Serially.Core.Models.Character;
using System;
using System.Threading.Tasks;

namespace Serially.Core.Services
{
  public interface IReplService
  {
    /// <summary>
    /// Write a character to the REPL
    /// </summary>
    Task WriteAsync(char c);

    /// <summary>
    /// Print received data. Do not send console input.
    /// </summary>
    Task TailAsync();

    /// <summary>
    /// Print received data and send console input.
    /// </summary>
    Task RunAsync();
  }

  /// <summary>
  /// Provides a Read-Eval-Print loop using Console.Write and Console.ReadKey
  /// </summary>
  public class ReplService : IReplService
  {
    private readonly SerialConfig _config = default;
    private readonly ISerialPortService _port = default;

    public ReplService(ISerialPortService port, SerialConfig config)
    {
      _port = port;
      _config = config;

      port.Received += HandleReceived;
    }

    private async void HandleReceived(object sender, Models.Streams.SerialReceivedEventArgs e)
    {
      Console.Write(await _port.ReadExistingAsync());
    }

    public async Task WriteAsync(char c)
    {
      if (_port.IsOpen)
      {
        await _port.WriteCharAsync(c).ConfigureAwait(false);
      }
    }

    public async Task TailAsync() => await RunAsync(true);
    public async Task RunAsync() => await RunAsync(false);

    private async Task RunAsync(bool tailOnly)
    {
      try
      {
        while (true)
        {
          await OpenPortAsync();
          await HandlePortOpened(tailOnly);
        }
      }
      finally
      {
        _port?.Close();
      }
    }

    private async Task HandlePortOpened(bool tailOnly)
    {
      do
      {
        try
        {
          await LoopOnceAsync(tailOnly);
        }
        catch (Exception)
        {
        }

      } while (_port.IsOpen);
    }

    private async Task LoopOnceAsync(bool tailOnly)
    {
      if (tailOnly)
      {
        return;
      }

      if (!Console.KeyAvailable)
      {
        return;
      }
      ConsoleKeyInfo info = Console.ReadKey(true);

      foreach (char c in Mapping.Map(info))
      {
        await WriteAsync(c).ConfigureAwait(false);
      }
    }

    private async Task<ISerialPortService> OpenPortAsync()
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
        await _port.OpenAsync(_config);
      }
      catch
      {
      }

      return _port.IsOpen;
    }
  }
}
