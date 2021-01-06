using Serially.Core.Models.Character;

namespace Serially.Core.Models.PortSettings
{
  /// <summary>
  /// A common implementation of DetailedPortSettings for XON/XOFF handshaking
  /// </summary>
  public class HandshakeXonXoff : DetailedPortSettings
  {
    /// <summary>
    /// Initialize the port
    /// </summary>
    protected override void Init()
    {
      base.Init();

      OutCTS = false;
      OutDSR = false;
      OutX = true;
      InX = true;
      RTSControl = RTSControlFlows.enable;
      DTRControl = DTRControlFlows.enable;
      TxContinueOnXOff = true;
      DSRSensitive = false;
      XonChar = (char)ASCII.DC1;
      XoffChar = (char)ASCII.DC3;
    }
  }
}
