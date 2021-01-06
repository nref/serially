namespace Serially.Core.Models.PortSettings
{
  /// <summary>
  /// A common implementation of DetailedPortSettings for DSR/DTR handshaking
  /// </summary>
  public class HandshakeDsrDtr : DetailedPortSettings
  {
    /// <summary>
    /// Initialize the port
    /// </summary>
    protected override void Init()
    {
      base.Init();

      OutCTS = false;
      OutDSR = true;
      OutX = false;
      InX = false;
      RTSControl = RTSControlFlows.enable;
      DTRControl = DTRControlFlows.handshake;
      TxContinueOnXOff = true;
      DSRSensitive = false;
    }
  }
}
