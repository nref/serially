namespace Serially.Core.Models.PortSettings
{
  /// <summary>
  /// A common implementation of DetailedPortSettings for non handshaking
  /// </summary>
  public class HandshakeNone : DetailedPortSettings
  {
    /// <summary>
    /// Initialize the port
    /// </summary>
    protected override void Init()
    {
      base.Init();

      OutCTS = false;
      OutDSR = false;
      OutX = false;
      InX = false;
      RTSControl = RTSControlFlows.enable;
      DTRControl = DTRControlFlows.enable;
      TxContinueOnXOff = true;
      DSRSensitive = false;
    }
  }
}
