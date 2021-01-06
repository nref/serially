using System;

namespace Serially.Core.Models.Windows
{
  /// <summary>
  /// Modem status flags
  /// </summary>
  [Flags]
  public enum CommModemStatusFlags : int
  {
    /// <summary>
    /// The CTS (Clear To Send) signal is on.
    /// </summary>
    MS_CTS_ON = 0x0010,
    /// <summary>
    /// The DSR (Data Set Ready) signal is on.
    /// </summary>
    MS_DSR_ON = 0x0020,
    /// <summary>
    /// The ring indicator signal is on.
    /// </summary>
    MS_RING_ON = 0x0040,
    /// <summary>
    /// The RLSD (Receive Line Signal Detect) signal is on.
    /// </summary>
    MS_RLSD_ON = 0x0080
  }
}