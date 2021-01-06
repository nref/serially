using Serially.Core.Models.Character;
using System.Runtime.InteropServices;

namespace Serially.Core.Models.PortSettings
{
  /// <summary>
  /// Used for manipulating all settings of a Port class
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public class DetailedPortSettings
  {
    /// <summary>
    /// Create a DetailedPortSettings class
    /// </summary>
    public DetailedPortSettings()
    {
      BasicSettings = new BasicPortSettings();
      Init();
    }

    /// <summary>
    /// These are the default port settings
    /// override Init() to create new defaults (i.e. common handshaking)
    /// </summary>
    protected virtual void Init()
    {
      BasicSettings.BaudRate = BaudRates.CBR_19200;
      BasicSettings.ByteSize = 8;
      BasicSettings.Parity = Parity.None;
      BasicSettings.StopBits = StopBits.One;

      OutCTS = false;
      OutDSR = false;
      DTRControl = DTRControlFlows.disable;
      DSRSensitive = false;
      TxContinueOnXOff = true;
      OutX = false;
      InX = false;
      ReplaceErrorChar = false;
      RTSControl = RTSControlFlows.disable;
      DiscardNulls = false;
      AbortOnError = false;
      XonChar = (char)ASCII.DC1;
      XoffChar = (char)ASCII.DC3;
      ErrorChar = (char)ASCII.NAK;
      EOFChar = (char)ASCII.EOT;
      EVTChar = (char)ASCII.NULL;
    }

    /// <summary>
    /// Basic port settings
    /// </summary>
    public BasicPortSettings BasicSettings;
    /// <summary>
    /// Specifies if the CTS (clear-to-send) signal is monitored for output flow control. If this member is TRUE and CTS is turned off, output is suspended until CTS is sent again.
    /// </summary>
    public bool OutCTS = false;
    /// <summary>
    /// Specifies if the DSR (data-set-ready) signal is monitored for output flow control. If this member is TRUE and DSR is turned off, output is suspended until DSR is sent again. 
    /// </summary>
    public bool OutDSR = false;
    /// <summary>
    /// Specifies the DTR (data-terminal-ready) flow control.
    /// </summary>
    public DTRControlFlows DTRControl = DTRControlFlows.disable;
    /// <summary>
    /// Specifies if the communications driver is sensitive to the state of the DSR signal. If this member is TRUE, the driver ignores any bytes received, unless the DSR modem input line is high.
    /// </summary>
    public bool DSRSensitive = false;
    /// <summary>
    /// Specifies if transmission stops when the input buffer is full and the driver has transmitted the XoffChar character. If this member is TRUE, transmission continues after the input buffer has come within XoffLim bytes of being full and the driver has transmitted the XoffChar character to stop receiving bytes. If this member is FALSE, transmission does not continue until the input buffer is within XonLim bytes of being empty and the driver has transmitted the XonChar character to resume reception.
    /// </summary>
    public bool TxContinueOnXOff = true;
    /// <summary>
    /// Specifies if XON/XOFF flow control is used during transmission. If this member is TRUE, transmission stops when the XoffChar character is received and starts again when the XonChar character is received.
    /// </summary>
    public bool OutX = false;
    /// <summary>
    /// Specifies if XON/XOFF flow control is used during reception. If this member is TRUE, the XoffChar character is sent when the input buffer comes within XoffLim bytes of being full, and the XonChar character is sent when the input buffer comes within XonLim bytes of being empty
    /// </summary>
    public bool InX = false;
    /// <summary>
    /// Specifies if bytes received with parity errors are replaced with the character specified by the ErrorChar member. If this member is TRUE and the fParity member is TRUE, replacement occurs.
    /// </summary>
    public bool ReplaceErrorChar = false;
    /// <summary>
    /// Specifies the RTS (request-to-send) flow control. If this value is zero, the default is RTS_CONTROL_HANDSHAKE. The following table shows possible values for this member.
    /// </summary>
    public RTSControlFlows RTSControl = RTSControlFlows.disable;
    /// <summary>
    /// Specifies if null bytes are discarded. If this member is TRUE, null bytes are discarded when received. 
    /// </summary>
    public bool DiscardNulls = false;
    /// <summary>
    /// Specifies if read and write operations are terminated if an error occurs. If this member is TRUE, the driver terminates all read and write operations with an error status if an error occurs. The driver will not accept any further communications operations until the application has acknowledged the error by calling the ClearError function.
    /// </summary>
    public bool AbortOnError = false;
    /// <summary>
    /// Specifies the value of the XON character for both transmission and reception
    /// </summary>
    public char XonChar = (char)ASCII.DC1;
    /// <summary>
    /// Specifies the value of the XOFF character for both transmission and reception.
    /// </summary>
    public char XoffChar = (char)ASCII.DC3;
    /// <summary>
    /// Specifies the value of the character used to replace bytes received with a parity error.
    /// </summary>
    public char ErrorChar = (char)ASCII.NAK;
    /// <summary>
    /// Specifies the value of the character used to signal the end of data. 
    /// </summary>
    public char EOFChar = (char)ASCII.EOT;
    /// <summary>
    /// Specifies the value of the character used to signal an event.
    /// </summary>
    public char EVTChar = (char)ASCII.NULL;
  }
}
