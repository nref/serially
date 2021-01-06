namespace Serially.Core
{
  public class SerialConfig
  {
    public const string DefaultPortName = "COM1";
    public const int DefaultBaudRate = 9600;
    public const Parity DefaultParity = Parity.None;
    public const StopBits DefaultStopBits = StopBits.One;
    public const Handshake DefaultHandshake = Handshake.None;
    public const int DefaultDataBits = 8;
    public const bool DefaultDiscardNull = false;
    public const bool DefaultDtrEnable = false;
    public const byte DefaultParityReplace = 0;
    public const int DefaultReadBufferSize = 512;
    public const int DefaultReadTimeout = 0;
    public const int DefaultReceivedBytesThreshold = 1;
    public const bool DefaultRtsEnable = false;
    public const int DefaultWriteBufferSize = 1024;
    public const int DefaultWriteTimeout = 0;

    public string PortName = DefaultPortName;
    public int BaudRate = DefaultBaudRate;
    public Parity CurrentParity = DefaultParity;
    public StopBits CurrentStopBits = DefaultStopBits;
    public Handshake CurrentHandshake = DefaultHandshake;
    public int DataBits = DefaultDataBits;
    public bool DiscardNull = DefaultDiscardNull;
    public bool DtrEnable = DefaultDtrEnable;
    public byte ParityReplace = DefaultParityReplace;
    public int ReadBufferSize = DefaultReadBufferSize;
    public int ReadTimeout = DefaultReadTimeout;
    public int ReceivedBytesThreshold = DefaultReceivedBytesThreshold;
    public bool RtsEnable = DefaultRtsEnable;
    public int WriteBufferSize = DefaultWriteBufferSize;
    public int WriteTimeout = DefaultWriteTimeout;
  }
}