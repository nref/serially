using Serially.Core.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Serially.Core
{
  public delegate void PortsChangedEvent(HashSet<string> previous, HashSet<string> current);
  public delegate void PortChangedEvent(string port);

  public interface IPortChangeWatcher
  {
    event PortChangedEvent PortAdded;
    event PortChangedEvent PortRemoved;
    HashSet<string> Ports { get; }

    void Cancel();
  }

  /// <summary>
  /// Notifies of add/remove of COM ports
  /// </summary>
  public class PortChangeWatcher : IPortChangeWatcher
  {
    public event PortChangedEvent PortAdded;
    public event PortChangedEvent PortRemoved;

    private HashSet<string> _ports = new HashSet<string>();

    public HashSet<string> Ports
    {
      get => _ports;
      set
      {
        if (!_ports.SetEquals(value))
        {
          HashSet<string> previous = _ports;
          _ports = value;
          HandlePortsChanged(previous, value);
        }
      }
    }

    private readonly CancellationTokenSource _cts = new CancellationTokenSource();

    public PortChangeWatcher()
    {
      Task.Run(async () => await Watch(_cts.Token), _cts.Token);
    }

    private async Task Watch(CancellationToken ct = default)
    {
      while (!ct.IsCancellationRequested)
      {
        Ports = new HashSet<string>(WinStream.GetPortNames());
        await Task.Delay(1000, ct);
      }
    }

    public void Cancel() => _cts.Cancel();

    private void HandlePortsChanged(HashSet<string> previous, HashSet<string> current)
    {
      IEnumerable<string> added = current.Except(previous);
      IEnumerable<string> removed = previous.Except(current);

      foreach (var port in added)
      {
        NotifyPortAdded(port);
      }

      foreach (var port in removed)
      {
        NotifyPortRemoved(port);
      }
    }

    private void NotifyPortAdded(string port) => PortAdded?.Invoke(port);
    private void NotifyPortRemoved(string port) => PortRemoved?.Invoke(port);
  }
}
