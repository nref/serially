using Serially.Core.Infrastructure.Pinvoke;
using Serially.Core.Models.Windows;
using System;

namespace Serially.Core.Models.CommApi
{
  public class WinCommAPI : CommAPI
  {
    public override IntPtr CreateFile(string FileName) => Kernel32.WinCreateFileW(FileName, CreateAccess, 0, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, IntPtr.Zero);

    // setting AccessMask to 0 returns a handle we can use to query the device without accessing it
    public override IntPtr QueryFile(string FileName) => Kernel32.WinCreateFileW(FileName, 0, 0, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, IntPtr.Zero);
    public override bool WaitCommEvent(IntPtr hPort, ref CommEventFlags flags) => Convert.ToBoolean(Kernel32.WinWaitCommEvent(hPort, ref flags, IntPtr.Zero));
    public override bool ClearCommError(IntPtr hPort, ref CommErrorFlags flags, CommStat stat) => Convert.ToBoolean(Kernel32.WinClearCommError(hPort, ref flags, stat));
    public override bool GetCommModemStatus(IntPtr hPort, ref uint lpModemStat) => Convert.ToBoolean(Kernel32.WinGetCommModemStatus(hPort, ref lpModemStat));
    public override bool SetCommMask(IntPtr hPort, CommEventFlags dwEvtMask) => Convert.ToBoolean(Kernel32.WinSetCommMask(hPort, dwEvtMask));
    public override bool ReadFile(IntPtr hPort, byte[] buffer, int cbToRead, ref int cbRead, IntPtr lpOverlapped) => Convert.ToBoolean(Kernel32.WinReadFile(hPort, buffer, cbToRead, ref cbRead, lpOverlapped));
    public override bool WriteFile(IntPtr hPort, byte[] buffer, int cbToWrite, ref int cbWritten, IntPtr lpOverlapped) => Convert.ToBoolean(Kernel32.WinWriteFile(hPort, buffer, cbToWrite, ref cbWritten, lpOverlapped));
    public override bool CloseHandle(IntPtr hPort) => Convert.ToBoolean(Kernel32.WinCloseHandle(hPort));
    public override bool SetupComm(IntPtr hPort, int dwInQueue, int dwOutQueue) => Convert.ToBoolean(Kernel32.WinSetupComm(hPort, dwInQueue, dwOutQueue));
    public override bool SetCommState(IntPtr hPort, DCB dcb) => Convert.ToBoolean(Kernel32.WinSetCommState(hPort, dcb));
    public override bool GetCommState(IntPtr hPort, DCB dcb) => Convert.ToBoolean(Kernel32.WinGetCommState(hPort, dcb));
    public override bool SetCommTimeouts(IntPtr hPort, CommTimeouts timeouts) => Convert.ToBoolean(Kernel32.WinSetCommTimeouts(hPort, timeouts));
    public override bool EscapeCommFunction(IntPtr hPort, CommEscapes escape) => Convert.ToBoolean(Kernel32.WinEscapeCommFunction(hPort, (uint)escape));
    public override IntPtr CreateEvent(bool bManualReset, bool bInitialState, string lpName) => Kernel32.WinCreateEvent(IntPtr.Zero, Convert.ToInt32(bManualReset), Convert.ToInt32(bInitialState), lpName);
    public override bool SetEvent(IntPtr hEvent) => Convert.ToBoolean(Kernel32.WinSetEvent(hEvent));
    public override bool ResetEvent(IntPtr hEvent) => Convert.ToBoolean(Kernel32.WinResetEvent(hEvent));
    public override bool PulseEvent(IntPtr hEvent) => Convert.ToBoolean(Kernel32.WinPulseEvent(hEvent));
    public override int WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds) => Kernel32.WinWaitForSingleObject(hHandle, dwMilliseconds);
    public override bool GetCommProperties(IntPtr hPort, CommCapabilities commcap) => Convert.ToBoolean(Kernel32.WinGetCommProperties(hPort, commcap));
    public override bool FlushFileBuffers(IntPtr hFile) => Convert.ToBoolean(Kernel32.WinFlushFileBuffers(hFile));
  }
}