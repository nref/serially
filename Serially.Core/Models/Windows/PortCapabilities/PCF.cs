using System;

namespace Serially.Core.Models.Windows.PortCapabilities
{
  //
  // Provider capabilities flags.
  //
  /// <summary>
  /// PCF enumerates the provider capabilites supported by the specified COMx: Port. This enumeration
  /// is used internaly only. Access to this bitfield information is provided through attributes of the
  /// CommProp class.
  /// </summary>
  [Flags]
  internal enum PCF
  {
    PCF_DTRDSR = 0x0001,
    PCF_RTSCTS = 0x0002,
    PCF_RLSD = 0x0004,
    PCF_PARITY_CHECK = 0x0008,
    PCF_XONXOFF = 0x0010,
    PCF_SETXCHAR = 0x0020,
    PCF_TOTALTIMEOUTS = 0x0040,
    PCF_INTTIMEOUTS = 0x0080,
    PCF_SPECIALCHARS = 0x0100,
    PCF_16BITMODE = 0x0200
  };
}