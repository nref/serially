using System.ComponentModel;

namespace Serially.Core.Models.PortSettings
{
  public enum Handshake
  {
    [Description("None")] None = 0,
    [Description("Xon/Xoff")] XOnXOff = 1,
    [Description("RTS")] RequestToSend = 2,
    [Description("Xon/RTS")] RequestToSendXOnXOff = 3,
  }
}
