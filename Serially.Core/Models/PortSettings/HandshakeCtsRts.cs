namespace Serially.Core.Models.PortSettings
{
  /// <summary>
  /// A common implementation of DetailedPortSettings for CTS/RTS handshaking
  /// </summary>
  public class HandshakeCtsRts : DetailedPortSettings
  {
    /// <summary>
    /// Initialize the port
    /// </summary>
    protected override void Init()
    {
      base.Init();

      OutCTS = true;
      OutDSR = false;
      OutX = false;
      InX = false;
      RTSControl = RTSControlFlows.handshake;
      DTRControl = DTRControlFlows.enable;
      TxContinueOnXOff = true;
      DSRSensitive = false;
    }
  }
}
