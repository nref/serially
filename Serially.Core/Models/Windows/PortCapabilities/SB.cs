using System;

namespace Serially.Core.Models.Windows.PortCapabilities
{
  //
  // Settable Stop and Parity bits.
  //
  [Flags]
  internal enum SB
  {
    STOPBITS_10 = 0x00010000,
    STOPBITS_15 = 0x00020000,
    STOPBITS_20 = 0x00040000,
    PARITY_NONE = 0x01000000,
    PARITY_ODD = 0x02000000,
    PARITY_EVEN = 0x04000000,
    PARITY_MARK = 0x08000000,
    PARITY_SPACE = 0x10000000
  };
}