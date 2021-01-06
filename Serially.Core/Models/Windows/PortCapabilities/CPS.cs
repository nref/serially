using System;

namespace Serially.Core.Models.Windows.PortCapabilities
{
  //
  // Set dwProvSpec1 to COMMPROP_INITIALIZED to indicate that wPacketLength
  // is valid when calling GetCommProperties().
  //
  [Flags]
  internal enum CPS : uint
  {
    COMMPROP_INITIALIZED = 0xE73CF52E
  };
}