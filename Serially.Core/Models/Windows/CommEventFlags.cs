using System;

namespace Serially.Core.Models.Windows
{
  /// <summary>
  /// Event Flags
  /// </summary>
  [Flags]
  public enum CommEventFlags : int
  {
    /// <summary>
    /// No flags
    /// </summary>
    NONE = 0x0000, //
    /// <summary>
    /// Event on receive
    /// </summary>
    RXCHAR = 0x0001, // Any Character received
    /// <summary>
    /// Event when specific character is received
    /// </summary>
    RXFLAG = 0x0002, // Received specified flag character
    /// <summary>
    /// Event when the transmit buffer is empty
    /// </summary>
    TXEMPTY = 0x0004, // Tx buffer Empty
    /// <summary>
    /// Event on CTS state change
    /// </summary>
    CTS = 0x0008, // CTS changed
    /// <summary>
    /// Event on DSR state change
    /// </summary>
    DSR = 0x0010, // DSR changed
    /// <summary>
    /// Event on RLSD state change
    /// </summary>
    RLSD = 0x0020, // RLSD changed
    /// <summary>
    /// Event on BREAK
    /// </summary>
    BREAK = 0x0040, // BREAK received
    /// <summary>
    /// Event on line error
    /// </summary>
    ERR = 0x0080, // Line status error
    /// <summary>
    /// Event on ring detect
    /// </summary>
    RING = 0x0100, // ring detected
    /// <summary>
    /// Event on printer error
    /// </summary>
    PERR = 0x0200, // printer error
    /// <summary>
    /// Event on 80% high-water
    /// </summary>
    RX80FULL = 0x0400, // rx buffer is at 80%
    /// <summary>
    /// Provider event 1
    /// </summary>
    EVENT1 = 0x0800, // provider event
    /// <summary>
    /// Provider event 2
    /// </summary>
    EVENT2 = 0x1000, // provider event
    /// <summary>
    /// Event on CE power notification
    /// </summary>
    POWER = 0x2000, // wince power notification
    /// <summary>
    /// Mask for all flags under CE
    /// </summary>
    ALLCE = 0x3FFF,  // mask of all flags for CE
    /// <summary>
    /// Mask for all flags under desktop Windows
    /// </summary>
    ALLPC = BREAK | CTS | DSR | ERR | RING | RLSD | RXCHAR | RXFLAG | TXEMPTY
  }
}