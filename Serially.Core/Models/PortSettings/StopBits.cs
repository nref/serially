using System;
using System.ComponentModel;

namespace Serially.Core.Models.PortSettings
{
  [Flags]
  public enum StopBits
  {
    [Description("1")] One = 1,
    [Description("1.5")] OnePointFive = 2,
    [Description("2")] Two = 4,
  }
}
