using System;

namespace Serially.Core.Models.Streams
{
  public class SerialReceivedEventArgs : EventArgs
  {
    private readonly SerialReceived _EventType;

    public SerialReceived EventType => _EventType;

    public SerialReceivedEventArgs(SerialReceived eventType)
    {
      _EventType = eventType;
    }

    public override string ToString()
    {
      return "Serial Received Event: " + Enum.Format(typeof(SerialReceived), EventType, "G");
    }
  }
}
