using System.ComponentModel;

namespace Serially.Core.Models.PortSettings
{
  public enum Parity
  {
    [Description("None")] None = 0,
    [Description("Odd")] Odd = 1,
    [Description("Even")] Even = 2,
    [Description("Mark")] Mark = 3,
    [Description("Space")] Space = 4,
  }
}
