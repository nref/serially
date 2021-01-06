namespace Serially.Core.Models.Windows.PortCapabilities
{
  //
  // Provider SubTypes
  //
  /// <summary>
  /// PST enumerates the provider subtypes supported by the WIN32 serial APIs. PST indicates which
  /// Port is used for serial communication. Ports can either be physical or logical devices.
  /// </summary>
  public enum PST
  {
    /// <summary>
    /// no provider subtype specified
    /// </summary>
    PST_UNSPECIFIED = 0x00000000,
    /// <summary>
    /// RS232 Port
    /// </summary>
    PST_RS232 = 0x00000001,
    /// <summary>
    /// parallel port
    /// </summary>
    PST_PARALLELPORT = 0x00000002,
    /// <summary>
    /// RS422 Port
    /// </summary>
    PST_RS422 = 0x00000003,
    /// <summary>
    /// RS423 Port
    /// </summary>
    PST_RS423 = 0x00000004,
    /// <summary>
    /// RS449 Port
    /// </summary>
    PST_RS449 = 0x00000005,
    /// <summary>
    /// Modem
    /// </summary>
    PST_MODEM = 0x00000006,
    /// <summary>
    /// Fax
    /// </summary>
    PST_FAX = 0x00000021,
    /// <summary>
    /// Scanner
    /// </summary>
    PST_SCANNER = 0x00000022,
    /// <summary>
    /// unspecified network bridge
    /// </summary>
    PST_NETWORK_BRIDGE = 0x00000100,
    /// <summary>
    /// DEC's LAT Port
    /// </summary>
    PST_LAT = 0x00000101,
    /// <summary>
    /// Telnet connection
    /// </summary>
    PST_TCPIP_TELNET = 0x00000102,
    /// <summary>
    /// X.25 standard
    /// </summary>
    PST_X25 = 0x00000103
  };


}