using System;

namespace Serially.Core.Models.Windows.PortCapabilities
{
  //
  // Comm provider settable parameters.
  //
  /// <summary>
  /// SP 
  /// </summary>
  [Flags]
  internal enum SP
  {
    SP_PARITY = 0x0001,
    SP_BAUD = 0x0002,
    SP_DATABITS = 0x0004,
    SP_STOPBITS = 0x0008,
    SP_HANDSHAKING = 0x0010,
    SP_PARITY_CHECK = 0x0020,
    SP_RLSD = 0x0040
  };
}