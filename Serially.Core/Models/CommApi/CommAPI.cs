using Serially.Core.Models.Windows;
using System;

namespace Serially.Core.Models.CommApi
{
  public abstract class CommAPI
  {
    public const int INVALID_HANDLE_VALUE = -1;
    public const uint OPEN_EXISTING = 3;
    public const uint GENERIC_READ = 0x80000000;
    public const uint GENERIC_WRITE = 0x40000000;
    public const uint FILE_FLAG_OVERLAPPED = 0x40000000;
    public const uint CreateAccess = GENERIC_WRITE | GENERIC_READ;

    public static bool FullFramework => bFullFramework;

    // These functions wrap the P/Invoked API calls and:
    // - make the correct call based on whether we're running under the full or compact framework
    // - eliminate empty parameters and defaults
    //
    public static bool bFullFramework;

    static CommAPI()
    {
      bFullFramework = Environment.OSVersion.Platform != PlatformID.WinCE;
    }

    public virtual IntPtr CreateFile(string FileName) { return (IntPtr)0L; }
    public virtual IntPtr QueryFile(string FileName) { return (IntPtr)0L; }
    public virtual bool WaitCommEvent(IntPtr hPort, ref CommEventFlags flags) { return false; }
    public virtual bool ClearCommError(IntPtr hPort, ref CommErrorFlags flags, CommStat stat) { return false; }
    public virtual bool GetCommModemStatus(IntPtr hPort, ref uint lpModemStat) { return false; }
    public virtual bool SetCommMask(IntPtr hPort, CommEventFlags dwEvtMask) { return false; }
    public virtual bool ReadFile(IntPtr hPort, byte[] buffer, int cbToRead, ref int cbRead, IntPtr lpOverlapped) { return false; }
    public virtual bool WriteFile(IntPtr hPort, byte[] buffer, int cbToWrite, ref int cbWritten, IntPtr lpOverlapped) { return false; }
    public virtual bool CloseHandle(IntPtr hPort) { return false; }
    public virtual bool SetupComm(IntPtr hPort, int dwInQueue, int dwOutQueue) { return false; }
    public virtual bool SetCommState(IntPtr hPort, DCB dcb) { return false; }
    public virtual bool GetCommState(IntPtr hPort, DCB dcb) { return false; }
    public virtual bool SetCommTimeouts(IntPtr hPort, CommTimeouts timeouts) { return false; }
    public virtual bool EscapeCommFunction(IntPtr hPort, CommEscapes escape) { return false; }
    public virtual IntPtr CreateEvent(bool bManualReset, bool bInitialState, string lpName) { return (IntPtr)0L; }
    public virtual bool SetEvent(IntPtr hEvent) { return false; }
    public virtual bool ResetEvent(IntPtr hEvent) { return false; }
    public virtual bool PulseEvent(IntPtr hEvent) { return false; }
    public virtual int WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds) { return 0; }
    public virtual bool GetCommProperties(IntPtr hPort, CommCapabilities commcap) { return false; }
    public virtual bool FlushFileBuffers(IntPtr hFile) { return false; }
  }
}