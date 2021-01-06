using System;
using System.Runtime.InteropServices;

namespace Serially.Core.Models.Windows
{
  [StructLayout(LayoutKind.Sequential)]
  public struct Overlapped
  {
    public UIntPtr Internal;
    public UIntPtr InternalHigh;
    public uint Offset;
    public uint OffsetHigh;
    public IntPtr hEvent;
  }
}


