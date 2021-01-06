using System;

namespace Serially.Core.Models.Windows
{
  /// <summary>
  /// Error flags
  /// </summary>
  [Flags]
  public enum CommErrorFlags : int
  {
    /// <summary>
    /// Receive overrun
    /// </summary>
    RXOVER = 0x0001,
    /// <summary>
    /// Overrun
    /// </summary>
    OVERRUN = 0x0002,
    /// <summary>
    /// Parity error
    /// </summary>
    RXPARITY = 0x0004,
    /// <summary>
    /// Frame error
    /// </summary>
    FRAME = 0x0008,
    /// <summary>
    /// BREAK received
    /// </summary>
    BREAK = 0x0010,
    /// <summary>
    /// Transmit buffer full
    /// </summary>
    TXFULL = 0x0100,
    /// <summary>
    /// IO Error
    /// </summary>
    IOE = 0x0400,
    /// <summary>
    /// Requested mode not supported
    /// </summary>
    MODE = 0x8000
  }
}