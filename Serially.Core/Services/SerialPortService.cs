using Serially.Core.Infrastructure;
using Serially.Core.Models.PortSettings;
using Serially.Core.Models.Streams;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serially.Core.Services
{
  public interface ISerialPortService
  {
    /// <summary>
    /// Handles the error event of a SerialPort object.
    /// </summary>
    event SerialErrorEventHandler ErrorOccurred;

    /// <summary>
    /// Handles the serial received event of a SerialPort object.
    /// </summary>
    event SerialReceivedEventHandler Received;

    /// <summary>
    /// Handles the serial pin changed event of a SerialPort object.
    /// </summary>
    event SerialPinChangedEventHandler PinChanged;

    /// <summary>
    /// Gets the open or closed status of the SerialPort object.
    /// </summary>
    public bool IsOpen { get; }

    /// <summary>
    /// Gets or sets the value used to interpret the end of a call to WriteLine.
    /// </summary>
    public string NewLine { get; set; }

    /// <summary>
    /// Gets or sets the port for communications, including but not limited to all available COM ports.
    /// 
    /// <para/>
    /// Set the value with SerialConfig.CurrentPortName. Call Close() then Open(SerialConfig).
    /// </summary>
    public string PortName { get; }

    /// <summary>
    /// Gets or sets the character encoding for pre- and post-transmission conversion of text.
    /// </summary>
    public Encoding Encoding { get; set; }

    /// <summary>
    /// Opens a new serial port connection.
    /// </summary>
    Task OpenAsync(SerialConfig config);

    /// <summary>
    /// Closes the port connection, sets to false and disposes of the internal Stream object.
    /// </summary>
    void Close();

    /// <summary>
    /// Reads all immediately available characters, based on the encoding,
    /// in both the stream and the input buffer of the SerialPort object.
    /// </summary>
    Task<string> ReadExistingAsync();

    /// <summary>
    /// Reads a number of bytes from the SerialPort input buffer and writes those bytes into a character array at a given offset.
    /// </summary>
    public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken ct);

    /// <summary>
    /// Writes data to serial port output.
    /// </summary>
    public Task WriteAsync(byte[] buffer, int offset, int count);

    /// <summary>
    /// Writes the specified string and the NewLine value to the output buffer.
    /// </summary>
    public Task WriteLineAsync(string str);

    /// <summary>
    /// Write a single character to serial port output
    /// </summary>
    public Task WriteCharAsync(char c);
  }

  /// <summary>
  /// Provides access to a COM port via streams and reports data and errors via events.
  /// Closes when the port has been removed.
  /// </summary>
  public class SerialPortService : ISerialPortService, IDisposable
  {
    public event SerialErrorEventHandler ErrorOccurred;
    public event SerialReceivedEventHandler Received;
    public event SerialPinChangedEventHandler PinChanged;

    private readonly bool _isUserProvidedStream = false;
    private Stream _stream;
    private ISerialStreamCtrl _streamCtrl;
    private string _currentPortName;

    private readonly IPortChangeService _portService;

    public SerialPortService(IPortChangeService portService)
    {
      _portService = portService;
      _portService.PortRemoved += HandlePortRemoved_;
    }

    /// <summary>
    /// Create SerialPort with specified underlying stream/streamCtrl objects.
    /// </summary>
    public SerialPortService(Stream stream, ISerialStreamCtrl streamCtrl)
    {
      _isUserProvidedStream = true;
      _stream = stream;
      _streamCtrl = streamCtrl;
      _streamCtrl.ErrorOccurred += HandleErrorOccurred;
      _streamCtrl.PinChanged += HandlePinChanged;
      _streamCtrl.Received += HandleReceived;
    }

    private void HandlePortRemoved_(string port)
    {
      if (port == _currentPortName)
      {
        Console.WriteLine($"Port {port} removed");
        Close();
      }
    }

    private void HandleErrorOccurred(object src, SerialErrorEventArgs e) => ErrorOccurred?.Invoke(this, e);
    private void HandlePinChanged(object src, SerialPinChangedEventArgs e) => PinChanged?.Invoke(this, e);
    private void HandleReceived(object src, SerialReceivedEventArgs e) => Received?.Invoke(this, e);

    public void Close()
    {
      IsOpen.If(true, () =>
      {
        _stream.Flush();
        _stream.Close();
        _stream = null;
        _streamCtrl = null;
      });
    }

    /// <summary>
    /// Discards data from the serial driver's receive buffer.
    /// </summary>
    public void DiscardInBuffer() => IsOpen.If(true, () => _streamCtrl.DiscardInBuffer());

    /// <summary>
    /// Discards data from the serial driver's transmit buffer.
    /// </summary>
    public void DiscardOutBuffer() => IsOpen.If(true, () => _streamCtrl.DiscardOutBuffer());

    public async Task OpenAsync(SerialConfig config)
    {
      await IsOpen.IfAsync(false, async () =>
      {
        if (IsUserProvidedStream)
        {
          throw new InvalidOperationException("User Provided Stream cannot be re-opened");
        }

        _currentPortName = config.PortName;

        if (SerialStreamSocket.IsCompatible(config.PortName))
        {
          SerialStreamSocket devStream = await SerialStreamSocket.CreateInstance(config.PortName);

          _stream = devStream;
          _streamCtrl = devStream;
        }
        else
        {
          var devStream = new WinStream
          (
            config.BaudRate,
            config.DataBits,
            config.DiscardNull,
            config.DtrEnable,
            config.CurrentHandshake,
            config.CurrentParity,
            config.ParityReplace,
            config.PortName,
            config.ReadBufferSize,
            config.ReadTimeout,
            config.ReceivedBytesThreshold,
            config.RtsEnable,
            config.CurrentStopBits,
            config.WriteBufferSize,
            config.WriteTimeout
          );

          _stream = devStream;
          _streamCtrl = devStream;
          _streamCtrl.ErrorOccurred += HandleErrorOccurred;
          _streamCtrl.PinChanged += HandlePinChanged;
          _streamCtrl.Received += HandleReceived;
        }
      });
    }

    public async Task<string> ReadExistingAsync() => await IsOpen.If(true, async () =>
      {
        byte[] buf = new byte[_streamCtrl.BytesToRead];
        int bufRead = await ReadAsync(buf, 0, buf.Length, new CancellationTokenSource(1000).Token);
        return Encoding.GetString(buf, 0, bufRead);
      });

    public async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken ct)
      => await _stream.ReadAsync(buffer, offset, count, ct);

    public async Task WriteAsync(byte[] buffer, int offset, int count)
      => await IsOpen.If(true, async () 
      => await _stream.WriteAsync(buffer, offset, count));

    public async Task WriteLineAsync(string str) 
      => await IsOpen.If(true, async () =>
      {
        byte[] buf = Encoding.GetBytes(str + NewLine);
        await _stream.WriteAsync(buf, 0, buf.Length);
      });

    public async Task WriteCharAsync(char c)
      => await IsOpen.If(true, async () =>
      {
        byte[] buf = Encoding.GetBytes(new string(c, 1));
        await _stream.WriteAsync(buf, 0, buf.Length);
      });

    /// <summary>
    /// Gets the open or closed status of the SerialPort object.
    /// </summary>
    public bool IsOpen => _streamCtrl != null && _streamCtrl.IsOpen;

    /// <summary>
    /// Gets or sets the value used to interpret the end of a call to WriteLine.
    /// </summary>
    public string NewLine { get; set; } = Environment.NewLine;

    /// <summary>
    /// Gets or sets the port for communications, including but not limited to all available COM ports.
    /// 
    /// <para/>
    /// Set the value with SerialConfig.CurrentPortName. Call Close() then Open(SerialConfig).
    /// </summary>
    public string PortName => _currentPortName;

    /// <summary>
    /// Gets or sets the character encoding for pre- and post-transmission conversion of text.
    /// </summary>
    public Encoding Encoding { get; set; } = new ASCIIEncoding();

    /// <summary>
    /// True if this instance was created with the user supplied Stream and ISerialStreamCtrl objects
    /// </summary>
    public bool IsUserProvidedStream => _isUserProvidedStream;

    /// <summary>
    /// Gets the underlying Stream object for a SerialPort object.
    /// </summary>
    public Stream BaseStream => _stream;

    /// <summary>
    /// Gets or sets the serial baud rate.
    /// </summary>
    public int BaudRate
    {
      get => _streamCtrl.BaudRate;
      set => _streamCtrl.BaudRate = value;
    }

    /// <summary>
    /// Gets or sets the break signal state.
    /// </summary>
    public bool BreakState
    {
      get => _streamCtrl.BreakState;
      set => _streamCtrl.BreakState = value;
    }

    /// <summary>
    /// Gets the number of bytes of data in the receive buffer.
    /// </summary>
    public int BytesToRead => _streamCtrl.BytesToRead;

    /// <summary>
    /// Gets the number of bytes of data in the send buffer.
    /// </summary>
    public int BytesToWrite => _streamCtrl.BytesToWrite;

    /// <summary>
    /// Gets the state of the carrier detect line for the port.
    /// </summary>
    public bool CDHolding => _streamCtrl.CDHolding;

    /// <summary>
    /// Gets the state of the Clear-to-Send line.
    /// </summary>
    public bool CtsHolding => _streamCtrl.CtsHolding;

    /// <summary>
    /// Gets or sets the standard length of databits per byte.
    /// </summary>
    public int DataBits
    {
      get => _streamCtrl.DataBits;
      set => _streamCtrl.DataBits = value;
    }

    /// <summary>
    /// Gets or sets whether null characters are ignored when transmitted between the port and the receive buffer.
    /// </summary>
    public bool DiscardNull
    {
      get => _streamCtrl.DiscardNull;
      set => _streamCtrl.DiscardNull = value;
    }

    /// <summary>
    /// Gets the state of the Data Set Ready (DSR) signal.
    /// </summary>
    public bool DsrHolding => _streamCtrl.DsrHolding;

    /// <summary>
    /// Gets or sets enabling of the Data Terminal Ready (DTR) signal during serial communication.
    /// </summary>
    public bool DtrEnable
    {
      get => _streamCtrl.DtrEnable;
      set => _streamCtrl.DtrEnable = value;
    }

    /// <summary>
    /// Gets or sets the handshaking protocol for serial port transmission of data.
    /// </summary>
    public Handshake Handshake
    {
      get => _streamCtrl.Handshake;
      set => _streamCtrl.Handshake = value;
    }

    /// <summary>
    /// Gets or sets the parity-checking protocol.
    /// </summary>
    public Parity Parity
    {
      get => _streamCtrl.Parity;
      set => _streamCtrl.Parity = value;
    }

    /// <summary>
    /// Gets or sets the 8-bit character that is used to replace invalid characters in a data stream when a parity error occurs.
    /// </summary>
    public byte ParityReplace
    {
      get => _streamCtrl.ParityReplace;
      set => _streamCtrl.ParityReplace = value;
    }

    public int ReadBufferSize
    {
      get => _streamCtrl.ReadBufferSize;
      set => _streamCtrl.ReadBufferSize = value;
    }

    /// <summary>
    /// Gets or sets the number of milliseconds before a timeout occurs when a read operation does not finish.
    /// </summary>
    public int ReadTimeout
    {
      get => _streamCtrl.ReadTimeout;
      set => _streamCtrl.ReadTimeout = value;
    }

    /// <summary>
    /// Gets or sets the number of bytes in the internal input buffer before a ReceivedEvent is fired.
    /// </summary>
    public int ReceivedBytesThreshold
    {
      get => _streamCtrl.ReceivedBytesThreshold;
      set => _streamCtrl.ReceivedBytesThreshold = value;
    }

    /// <summary>
    /// Gets or sets whether the Request to Transmit (RTS) signal is enabled during serial communication.
    /// </summary>
    public bool RtsEnable
    {
      get => _streamCtrl.RtsEnable;
      set => _streamCtrl.RtsEnable = value;
    }

    /// <summary>
    /// Gets or sets the standard number of stopbits per byte.
    /// </summary>
    public StopBits StopBits
    {
      get => _streamCtrl.StopBits;
      set => _streamCtrl.StopBits = value;
    }

    public int WriteBufferSize
    {
      get => _streamCtrl.WriteBufferSize;
      set => _streamCtrl.WriteBufferSize = value;
    }

    /// <summary>
    /// Gets or sets the number of milliseconds before a timeout occurs when a write operation does not finish.
    /// </summary>
    public int WriteTimeout
    {
      get => _streamCtrl.WriteTimeout;
      set => _streamCtrl.WriteTimeout = value;
    }

    /// <summary>
    /// Releases the unmanaged resources used by the SerialPort object.
    /// </summary>
    protected void Dispose(bool disposing)
    {
      if (disposing && null != _stream)
        _stream.Close();
    }

    /// <summary>
    /// Releases the unmanaged resources used by the SerialPort object.
    /// </summary>
    public void Dispose() => Dispose(true);
  }
}
