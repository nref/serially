using System;

namespace Serially.Core.Models.Streams
{
  public class SerialPinChangedEventArgs : EventArgs
  {
    private readonly SerialPinChanges _EventType;

    public SerialPinChanges EventType => _EventType;

    public SerialPinChangedEventArgs(SerialPinChanges eventType)
    {
      _EventType = eventType;
    }

    public override string ToString()
    {
      return "Serial Pin Changed: " + Enum.Format(typeof(SerialPinChanges), EventType, "G");
    }
  }
}
