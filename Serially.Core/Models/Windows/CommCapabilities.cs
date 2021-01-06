using Serially.Core.Models.Windows.PortCapabilities;
using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace Serially.Core.Models.Windows
{
  /// <summary>
  /// Container for all available information on port's capabilties 
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public class CommCapabilities
  {
    private readonly ushort wPacketLength;
    private ushort wPacketVersion;
    /// <summary>
    /// Indicates which services are supported by the port. SP_SERIALCOMM is specified for communication
    /// providers, including modem providers.
    /// </summary>
    public SEP dwServiceMask;
    private uint dwReserved1;
    /// <summary>
    /// Specifies the maximum size, in bytes, of the driver's internal output buffer. A value of zero
    /// indicates that no maximum value is imposed by the driver.
    /// </summary>
    [CLSCompliant(false)]
    public uint dwMaxTxQueue;
    /// <summary>
    /// Specifies the maximum size, in bytes, of the driver's internal input buffer. A value of zero
    /// indicates that no maximum value is imposed by the driver.
    /// </summary>
    [CLSCompliant(false)]
    public uint dwMaxRxQueue;
    /// <summary>
    /// Specifies the maximum baud rate, in bits per second (bps).
    /// </summary>
    public BAUD dwMaxBaud;
    /// <summary>
    /// Specifies the communication provider type.
    /// </summary>
    public PST dwProvSubType;
    private BitVector32 dwProvCapabilities;
    private BitVector32 dwSettableParams;
    private BitVector32 dwSettableBaud;
    private BitVector32 dwSettableStopParityData;
    /// <summary>
    /// Specifies the size, in bytes, of the driver's internal output buffer. A value of zero indicates 
    /// that the value is unavailable.
    /// </summary>
    [CLSCompliant(false)]
    public uint dwCurrentTxQueue;
    /// <summary>
    /// Specifies the size, in bytes, of the driver's internal input buffer. A value of zero indicates 
    /// that the value is unavailable.
    /// </summary>
    [CLSCompliant(false)]
    public uint dwCurrentRxQueue;
    private CPS dwProvSpec1;
    private uint dwProvSpec2;
    private ushort wcProvChar;

    internal CommCapabilities()
    {
      wPacketLength = (ushort)Marshal.SizeOf(this);
      dwProvSpec1 = CPS.COMMPROP_INITIALIZED;

      dwProvCapabilities = new BitVector32(0);
      dwSettableParams = new BitVector32(0);
      dwSettableBaud = new BitVector32(0);
      dwSettableStopParityData = new BitVector32(0);
    }

    //
    // We need to have to define reserved fields in the CommCapabilties class definition
    // to preserve the size of the 
    // underlying structure to match the Win32 structure when it is 
    // marshaled. Use these fields to suppress compiler warnings.
    //
    internal void _SuppressCompilerWarnings()
    {
      wPacketVersion += 0;
      dwReserved1 += 0;
      dwProvSpec1 += 0;
      dwProvSpec2 += 0;
      wcProvChar += 0;
    }

    // Provider Capabilties
    /// <summary>
    /// Port supports special 16-bit mode
    /// </summary>
    public bool Supports16BitMode => dwProvCapabilities[(int)PCF.PCF_16BITMODE];

    /// <summary>
    /// Port supports DTR (Data Terminal ready) and DSR (Data Set Ready) flow control
    /// </summary>
    public bool SupportsDtrDts => dwProvCapabilities[(int)PCF.PCF_DTRDSR];

    /// <summary>
    /// Port supports interval timeouts
    /// </summary>
    public bool SupportsIntTimeouts => dwProvCapabilities[(int)PCF.PCF_INTTIMEOUTS];

    /// <summary>
    /// Port supports parity checking
    /// </summary>
    public bool SupportsParityCheck => dwProvCapabilities[(int)PCF.PCF_PARITY_CHECK];

    /// <summary>
    /// Port supports RLSD (Receive Line Signal Detect)
    /// </summary>
    public bool SupportsRlsd => dwProvCapabilities[(int)PCF.PCF_RLSD];

    /// <summary>
    /// Port supports RTS (Request To Send) and CTS (Clear To Send) flowcontrol
    /// </summary>
    public bool SupportsRtsCts => dwProvCapabilities[(int)PCF.PCF_RTSCTS];

    /// <summary>
    /// Port supports user definded characters for XON and XOFF
    /// </summary>
    public bool SupportsSetXChar => dwProvCapabilities[(int)PCF.PCF_SETXCHAR];

    /// <summary>
    /// Port supports special characters
    /// </summary>
    public bool SupportsSpecialChars => dwProvCapabilities[(int)PCF.PCF_SPECIALCHARS];

    /// <summary>
    /// Port supports total and elapsed time-outs
    /// </summary>
    public bool SupportsTotalTimeouts => dwProvCapabilities[(int)PCF.PCF_TOTALTIMEOUTS];

    /// <summary>
    /// Port supports XON/XOFF flow control
    /// </summary>
    public bool SupportsXonXoff => dwProvCapabilities[(int)PCF.PCF_XONXOFF];

    // Settable Params
    /// <summary>
    /// Baud rate can be set
    /// </summary>
    public bool SettableBaud => dwSettableParams[(int)SP.SP_BAUD];

    /// <summary>
    /// Number of data bits can be set
    /// </summary>
    public bool SettableDataBits => dwSettableParams[(int)SP.SP_DATABITS];

    /// <summary>
    /// Handshake protocol can be set
    /// </summary>
    public bool SettableHandShaking => dwSettableParams[(int)SP.SP_HANDSHAKING];

    /// <summary>
    /// Number of parity bits can be set
    /// </summary>
    public bool SettableParity => dwSettableParams[(int)SP.SP_PARITY];

    /// <summary>
    /// Parity check can be enabled/disabled
    /// </summary>
    public bool SettableParityCheck => dwSettableParams[(int)SP.SP_PARITY_CHECK];
    /// <summary>
    /// Receive Line Signal detect can be enabled/disabled
    /// </summary>
    public bool SettableRlsd => dwSettableParams[(int)SP.SP_RLSD];
    /// <summary>
    /// Number of stop bits can be set
    /// </summary>
    public bool SettableStopBits => dwSettableParams[(int)SP.SP_STOPBITS];

    // Settable Databits
    /// <summary>
    /// Port supports 5 data bits
    /// </summary>
    public bool Supports5DataBits => dwSettableStopParityData[(int)DB.DATABITS_5];

    /// <summary>
    /// Port supports 6 data bits
    /// </summary>
    public bool Supports6DataBits => dwSettableStopParityData[(int)DB.DATABITS_6];

    /// <summary>
    /// Port supports 7 data bits
    /// </summary>
    public bool Supports7DataBits => dwSettableStopParityData[(int)DB.DATABITS_7];

    /// <summary>
    /// Port supports 8 data bits
    /// </summary>
    public bool Supports8DataBits => dwSettableStopParityData[(int)DB.DATABITS_8];

    /// <summary>
    /// Port supports 16 data bits
    /// </summary>
    public bool Supports16DataBits => dwSettableStopParityData[(int)DB.DATABITS_16];

    /// <summary>
    /// Port supports special wide data path through serial hardware lines
    /// </summary>
    public bool Supports16XDataBits => dwSettableStopParityData[(int)DB.DATABITS_16X];

    // Settable Stop

    /// <summary>
    /// Port supports even parity
    /// </summary>
    public bool SupportsParityEven => dwSettableStopParityData[(int)SB.PARITY_EVEN];

    /// <summary>
    /// Port supports mark parity
    /// </summary>
    public bool SupportsParityMark => dwSettableStopParityData[(int)SB.PARITY_MARK];

    /// <summary>
    /// Port supports none parity
    /// </summary>
    public bool SupportsParityNone => dwSettableStopParityData[(int)SB.PARITY_NONE];

    /// <summary>
    /// Port supports odd parity
    /// </summary>
    public bool SupportsParityOdd => dwSettableStopParityData[(int)SB.PARITY_ODD];

    /// <summary>
    /// Port supports space parity
    /// </summary>
    public bool SupportsParitySpace => dwSettableStopParityData[(int)SB.PARITY_SPACE];

    /// <summary>
    /// Port supports 1 stop bit
    /// </summary>
    public bool SupportsStopBits10 => dwSettableStopParityData[(int)SB.STOPBITS_10];

    /// <summary>
    /// Port supports 1.5 stop bits
    /// </summary>
    public bool SupportsStopBits15 => dwSettableStopParityData[(int)SB.STOPBITS_15];

    /// <summary>
    /// Port supports 2 stop bits
    /// </summary>
    public bool SupportsStopBits20 => dwSettableStopParityData[(int)SB.STOPBITS_20];

    // settable Baud Rates
    /// <summary>
    /// Port can be set to 75 bits per second
    /// </summary>
    public bool HasBaud75 => dwSettableBaud[(int)BAUD.BAUD_075];
    /// <summary>
    /// Port can be set to 110 bits per second
    /// </summary>
    public bool HasBaud110 => dwSettableBaud[(int)BAUD.BAUD_110];
    /// <summary>
    /// Port can be set to 134.5 bits per second
    /// </summary>
    public bool HasBaud134_5 => dwSettableBaud[(int)BAUD.BAUD_134_5];
    /// <summary>
    /// Port can be set to 150 bits per second
    /// </summary>
    public bool HasBaud150 => dwSettableBaud[(int)BAUD.BAUD_150];

    /// <summary>
    /// Port can be set to 300 bits per second
    /// </summary>
    public bool HasBaud300 => dwSettableBaud[(int)BAUD.BAUD_300];

    /// <summary>
    /// Port can be set to 600 bits per second
    /// </summary>
    public bool HasBaud600 => dwSettableBaud[(int)BAUD.BAUD_600];

    /// <summary>
    /// Port can be set to 1,200 bits per second
    /// </summary>
    public bool HasBaud1200 => dwSettableBaud[(int)BAUD.BAUD_1200];

    /// <summary>
    /// Port can be set to 2,400 bits per second
    /// </summary>
    public bool HasBaud2400 => dwSettableBaud[(int)BAUD.BAUD_2400];

    /// <summary>
    /// Port can be set to 4,800 bits per second
    /// </summary>
    public bool HasBaud4800 => dwSettableBaud[(int)BAUD.BAUD_4800];

    /// <summary>
    /// Port can be set to 7,200 bits per second
    /// </summary>
    public bool HasBaud7200 => dwSettableBaud[(int)BAUD.BAUD_7200];

    /// <summary>
    /// Port can be set to 9,600 bits per second
    /// </summary>
    public bool HasBaud9600 => dwSettableBaud[(int)BAUD.BAUD_9600];

    /// <summary>
    /// Port can be set to 14,400 bits per second
    /// </summary>
    public bool HasBaud14400 => dwSettableBaud[(int)BAUD.BAUD_14400];

    /// <summary>
    /// Port can be set to 19,200 bits per second
    /// </summary>
    public bool HasBaud19200 => dwSettableBaud[(int)BAUD.BAUD_19200];

    /// <summary>
    /// Port can be set to 38,400 bits per second
    /// </summary>
    public bool HasBaud38400 => dwSettableBaud[(int)BAUD.BAUD_38400];

    /// <summary>
    /// Port can be set to 56 Kbits per second
    /// </summary>
    public bool HasBaud56K => dwSettableBaud[(int)BAUD.BAUD_56K];

    /// <summary>
    /// Port can be set to 128 Kbits per second
    /// </summary>
    public bool HasBaud128K => dwSettableBaud[(int)BAUD.BAUD_128K];

    /// <summary>
    /// Port can be set to 115,200 bits per second
    /// </summary>
    public bool HasBaud115200 => dwSettableBaud[(int)BAUD.BAUD_115200];

    /// <summary>
    /// Port can be set to 57,600 bits per second
    /// </summary>
    public bool HasBaud57600 => dwSettableBaud[(int)BAUD.BAUD_57600];

    /// <summary>
    /// Port can be set to user defined bit rate
    /// </summary>
    public bool HasBaudUser => dwSettableBaud[(int)BAUD.BAUD_USER];

  };


}