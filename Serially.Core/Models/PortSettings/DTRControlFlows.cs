namespace Serially.Core
{
  /// <summary>
  /// DTR Flow Control
  /// </summary>
  public enum DTRControlFlows
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
    handshake = 0x02
  }
}
