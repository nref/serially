using System;

namespace Serially.Core.Models.Windows.PortCapabilities
{
  //
  // Settable Data Bits
  //

  [Flags]
  internal enum DB
  {
    DATABITS_5 = 0x0001,
    DATABITS_6 = 0x0002,
    DATABITS_7 = 0x0004,
    DATABITS_8 = 0x0008,
    DATABITS_16 = 0x0010,
    DATABITS_16X = 0x0020
  };
}