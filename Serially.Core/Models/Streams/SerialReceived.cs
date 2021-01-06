using System;
using System.ComponentModel;

namespace Serially.Core.Models.Streams
{
  [Flags]
  public enum SerialReceived
  {
    [Description("Received Chars")] ReceivedChars = 1,
    [Description("End of Receive")] EofReceived = 2,
  }
}
