namespace Serially.Core.Models.PortSettings
{
  /// <summary>
  /// RTS Flow Control
  /// </summary>
  public enum RTSControlFlows
  {
    /// <summary>
    /// Disabled
    /// </summary>
    disable = 0x00,
    /// <summary>
    /// Enabled
    /// </summary>
    enable = 0x01,
    /// <summary>
    /// Determined by handshaking
    /// </summary>
    handshake = 0x02,
    /// <summary>
    /// Toggle
    /// </summary>
    toggle = 0x03
  }
}
