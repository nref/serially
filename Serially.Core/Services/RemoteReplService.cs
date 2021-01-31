using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace Serially.Core.Services
{
  public interface IRemoteReplService
  {
    IRemoteReplService RunAsync(CancellationToken ct = default);
  }

  /// <summary>
  /// Read from stdin and expose as an observable
  /// </summary>
  public class RemoteReplService : IRemoteReplService
  {
    private readonly IReplService _repl;

    public RemoteReplService(IReplService repl)
    {
      _repl = repl;
    }

    public IRemoteReplService RunAsync(CancellationToken ct = default)
    {
      Task.Run(async () =>
      {
        var pipe = new NamedPipeServerStream($"{nameof(RemoteReplService)}",
          PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances);

        while (!ct.IsCancellationRequested)
        {
          try
          {
            await pipe.WaitForConnectionAsync(ct);
            using var reader = new StreamReader(pipe, leaveOpen: true);

            int i;
            while ((i = reader.Read()) > 0 && !ct.IsCancellationRequested)
            {
              await _repl.WriteAsync((char)i);
            }
          }
          catch (IOException)
          {
            pipe.Disconnect();
          }
          catch (Exception e)
          {
            Console.WriteLine(e);
          }
        }

      }, ct);

      return this;
    }
  }
}
