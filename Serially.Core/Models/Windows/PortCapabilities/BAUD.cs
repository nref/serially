using System;

namespace Serially.Core.Models.Windows.PortCapabilities
{
  //
  // Settable baud rates in the provider.
  //
  /// <summary>
  /// baud rates settable by Comm API 
  /// </summary>
  [Flags]
  public enum BAUD
  {
    /// <summary>
    /// 75 bits per second
    /// </summary>
    BAUD_075 = 0x00000001,
    /// <summary>
    /// 110 bits per second
    /// </summary>
    BAUD_110 = 0x00000002,
    /// <summary>
    /// 134.5 bits per second
    /// </summary>
    BAUD_134_5 = 0x00000004,
    /// <summary>
    /// 150 bits per second
    /// </summary>
    BAUD_150 = 0x00000008,
    /// <summary>
    /// 300 bits per second
    /// </summary>
    BAUD_300 = 0x00000010,
    /// <summary>
    /// 600 bits per second
    /// </summary>
    BAUD_600 = 0x00000020,
    /// <summary>
    /// 1,200 bits per second
    /// </summary>
    BAUD_1200 = 0x00000040,
    /// <summary>
    /// 1,800 bits per second
    /// </summary>
    BAUD_1800 = 0x00000080,
    /// <summary>
    /// 2,400 bits per second
    /// </summary>
    BAUD_2400 = 0x00000100,
    /// <summary>
    /// 4,800 bits per second
    /// </summary>
    BAUD_4800 = 0x00000200,
    /// <summary>
    /// 7,200 bits per second
    /// </summary>
    BAUD_7200 = 0x00000400,
    /// <summary>
    /// 9,600 bits per second
    /// </summary>
    BAUD_9600 = 0x00000800,
    /// <summary>
    /// 14,400 bits per second
    /// </summary>
    BAUD_14400 = 0x00001000,
    /// <summary>
    /// 19,200 bits per second
    /// </summary>
    BAUD_19200 = 0x00002000,
    /// <summary>
    /// 38,400 bits per second
    /// </summary>
    BAUD_38400 = 0x00004000,
    /// <summary>
    /// 56 Kbits per second
    /// </summary>
    BAUD_56K = 0x00008000,
    /// <summary>
    /// 129 Kbits per second
    /// </summary>
    BAUD_128K = 0x00010000,
    /// <summary>
    /// 115,200 bits per second
    /// </summary>
    BAUD_115200 = 0x00020000,
    /// <summary>
    /// 57,600 bits per second
    /// </summary>
    BAUD_57600 = 0x00040000,
    /// <summary>
    /// User defined bitrates
    /// </summary>
    BAUD_USER = 0x10000000
  };


}