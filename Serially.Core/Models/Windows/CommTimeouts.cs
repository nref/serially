using System.Runtime.InteropServices;

namespace Serially.Core.Models.Windows
{
  [StructLayout(LayoutKind.Sequential)]
  public class CommTimeouts
  {
    public uint ReadIntervalTimeout;
    public uint ReadTotalTimeoutMultiplier;
    public uint ReadTotalTimeoutConstant;
    public uint WriteTotalTimeoutMultiplier;
    public uint WriteTotalTimeoutConstant;
  }
}