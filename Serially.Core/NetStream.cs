using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Serially.Core.Streams
{
  /// <summary>
  /// This class is a wrapper on top of the NetworkStream.
  /// Use it when serial port gets exposed as a network port
  /// </summary>
  public class SerialStreamSocket : NetworkStream, ISerialStreamCtrl
  {
    public class Consts
    {
      public const int FIONREAD = 0x4004667F;
    }

    /// <summary>
    /// Checks if portName has the format of a networked serial port:  "ip_address:port"
    /// </summary>
    /// <param name="portName"></param>
    /// <returns></returns>
    public static bool IsCompatible(string portName)
    {
      // quick and dirty way - must have 1 collon and 1 or more dots, and end in a digit
      int collonInd = portName.IndexOf(':');

      if (collonInd > 0 && collonInd < portName.Length &&
          collonInd == portName.LastIndexOf(':') &&
          portName.IndexOf('.') > 0 &&
          char.IsDigit(portName, portName.Length - 1)
        )
        return true;
      else
        return false;
    }

    public static async Task<SerialStreamSocket> CreateInstance(string portName)
    {
      if (portName == null)
        throw new ArgumentNullException("portName");

      string[] strParts = portName.Split(':');

      if (strParts.Length != 2)
        throw new ArgumentException("Invalid format", "portName");

      // Get port number
      int port = int.Parse(strParts[1]);

      // Get host related information.
      IPHostEntry iphe = await Dns.GetHostEntryAsync(strParts[0]);

      // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
      // an exception to be thrown if the host IP Address is not compatible with the address family
      // (typical in the IPv6 case).
      foreach (IPAddress ipad in iphe.AddressList)
      {
        IPEndPoint ipe = new IPEndPoint(ipad, port);
        Socket socket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        socket.Connect(ipe);
        if (socket.Connected)
          return new SerialStreamSocket(socket);
      }

      throw new ApplicationException("Unable to connect");
    }

    public SerialStreamSocket(Socket socket) : base(socket)
    { }

    public int BaudRate
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public bool BreakState
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public int BytesToRead
    {
      get
      {
        // 0x4004667F
        // IOVT T|vendor/addr fmly|  code
        // 0100 0|000  0000 0100  |  0110 0110  0111 1111
        //
        byte[] outValue = BitConverter.GetBytes(0);    // (int)0 -> byte[4]

        // Check how many bytes have been received.
        base.Socket.IOControl(Consts.FIONREAD, null, outValue);

        return (int)BitConverter.ToUInt32(outValue, 0);
      }
    }

    public int BytesToWrite => 0;

    public bool CDHolding => throw new NotImplementedException();

    public bool CtsHolding => throw new NotImplementedException();

    public int DataBits
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public bool DiscardNull
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public bool DsrHolding => throw new NotImplementedException();

    public bool DtrEnable
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public static string[] GetPortNames()
    {
      throw new NotImplementedException();
    }

    public Handshake Handshake
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public bool IsOpen => throw new NotImplementedException();

    public Parity Parity
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public byte ParityReplace
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public int ReadBufferSize
    {
      get => (int)base.Socket.GetSocketOption(
              SocketOptionLevel.Socket,
              SocketOptionName.ReceiveBuffer);
      set => base.Socket.SetSocketOption(
              SocketOptionLevel.Socket,
              SocketOptionName.ReceiveBuffer,
              value);
    }

    public int ReadTimeout
    {
      get => (int)base.Socket.GetSocketOption(
              SocketOptionLevel.Socket,
              SocketOptionName.ReceiveTimeout);
      set => base.Socket.SetSocketOption(
              SocketOptionLevel.Socket,
              SocketOptionName.ReceiveTimeout,
              value);
    }

    public int ReceivedBytesThreshold
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public bool RtsEnable
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public StopBits StopBits
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

    public int WriteBufferSize
    {
      get => (int)base.Socket.GetSocketOption(
              SocketOptionLevel.Socket,
              SocketOptionName.SendBuffer);
      set => base.Socket.SetSocketOption(
              SocketOptionLevel.Socket,
              SocketOptionName.SendBuffer,
              value);
    }

    public int WriteTimeout
    {
      get => (int)base.Socket.GetSocketOption(
              SocketOptionLevel.Socket,
              SocketOptionName.SendTimeout);
      set => base.Socket.SetSocketOption(
              SocketOptionLevel.Socket,
              SocketOptionName.SendTimeout,
              value);
    }


    public event SerialErrorEventHandler ErrorOccurred
    {
      add { throw new NotImplementedException(); }
      remove { throw new NotImplementedException(); }
    }

    public event SerialReceivedEventHandler Received
    {
      add { throw new NotImplementedException(); }
      remove { throw new NotImplementedException(); }
    }

    public event SerialPinChangedEventHandler PinChanged
    {
      add { throw new NotImplementedException(); }
      remove { throw new NotImplementedException(); }
    }


    public void DiscardInBuffer()
    {
      throw new NotImplementedException();
    }

    public void DiscardOutBuffer()
    {
      throw new NotImplementedException();
    }
  }
}