using System.Runtime.InteropServices;

namespace Serially.Core.Models.PortSettings
{
  /// <summary>
  /// Used for manipulating several basic Port settings of a Port class
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public class BasicPortSettings
  {
    /// <summary>
    /// Baud rate (default = 19200bps)
    /// </summary>
    public BaudRates BaudRate = BaudRates.CBR_19200;
    /// <summary>
    /// Byte Size of data (default = 8)
    /// </summary>
    public byte ByteSize = 8;
    /// <summary>
    /// Data Parity (default = none)
    /// </summary>
    public Parity Parity = Parity.None;
    /// <summary>
    /// Number of stop bits (default = 1)
    /// </summary>
    public StopBits StopBits = StopBits.One;
  }
}
