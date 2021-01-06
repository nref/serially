namespace Serially.Core.Models.PortSettings
{
  /// <summary>
  /// CE-supported baud rates (check your hardware for actual availability)
  /// </summary>
  public enum BaudRates : int
  {
    /// <summary>
    /// 110bpb
    /// </summary>
    CBR_110 = 110,
    /// <summary>
    /// 300bps
    /// </summary>
    CBR_300 = 300,
    /// <summary>
    /// 600bps
    /// </summary>
    CBR_600 = 600,
    /// <summary>
    /// 1200bps
    /// </summary>
    CBR_1200 = 1200,
    /// <summary>
    /// 2400bps
    /// </summary>
    CBR_2400 = 2400,
    /// <summary>
    /// 4800bps
    /// </summary>
    CBR_4800 = 4800,
    /// <summary>
    /// 9600bps
    /// </summary>
    CBR_9600 = 9600,
    /// <summary>
    /// 14.4kbps
    /// </summary>
    CBR_14400 = 14400,
    /// <summary>
    /// 19.2kbps
    /// </summary>
    CBR_19200 = 19200,
    /// <summary>
    /// 38.4kbps
    /// </summary>
    CBR_38400 = 38400,
    /// <summary>
    /// 56kbps
    /// </summary>
    CBR_56000 = 56000,
    /// <summary>
    /// 57.6kbps
    /// </summary>
    CBR_57600 = 57600,
    /// <summary>
    /// 115kbps
    /// </summary>
    CBR_115200 = 115200,
    /// <summary>
    /// 128kbps
    /// </summary>
    CBR_128000 = 128000,
    /// <summary>
    /// 225kbps
    /// </summary>
    CBR_230400 = 230400,
    /// <summary>
    /// 256kbps
    /// </summary>
    CBR_256000 = 256000,
    /// <summary>
    /// 450kbps
    /// </summary>
    CBR_460800 = 460800,
    /// <summary>
    /// 900kbps
    /// </summary>
    CBR_921600 = 921600,
  }
}
