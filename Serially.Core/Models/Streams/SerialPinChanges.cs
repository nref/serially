using System;
using System.ComponentModel;

namespace Serially.Core.Models.Streams
{
  [Flags]
  public enum SerialPinChanges
  {
    [Description("CTS Changed")] CtsChanged = 8,
    [Description("DSR Changed")] DsrChanged = 16,
    [Description("CD Changed")] CDChanged = 32,
    [Description("Break")] Break = 64,
    [Description("Ring")] Ring = 256,
  }
}
