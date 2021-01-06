using System;

namespace Serially.Core.Models.Streams
{
  public class SerialErrorEventArgs : EventArgs
  {
    private readonly SerialErrors _EventType;

    public SerialErrors EventType => _EventType;

    public SerialErrorEventArgs(SerialErrors eventType)
    {
      _EventType = eventType;
    }

    public override string ToString()
    {
      return "UART Error: " + Enum.Format(typeof(SerialErrors), EventType, "G");
    }
  }
}
