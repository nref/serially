using Serially.Core.Infrastructure.Pinvoke;
using Serially.Core.Models.Windows;
using System;

namespace Serially.Core.Models.CommApi
{
  public class CECommAPI : CommAPI
  {
    public override IntPtr CreateFile(string FileName) => CoreDll.CECreateFileW(FileName, CreateAccess, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

    // setting AccessMask to 0 returns a handle we can use to query the device without accessing it
    public override IntPtr QueryFile(string FileName) => CoreDll.CECreateFileW(FileName, 0, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
    public override bool WaitCommEvent(IntPtr hPort, ref CommEventFlags flags) => Convert.ToBoolean(CoreDll.CEWaitCommEvent(hPort, ref flags, IntPtr.Zero));
    public override bool ClearCommError(IntPtr hPort, ref CommErrorFlags flags, CommStat stat) => Convert.ToBoolean(CoreDll.CEClearCommError(hPort, ref flags, stat));
    public override bool GetCommModemStatus(IntPtr hPort, ref uint lpModemStat) => Convert.ToBoolean(CoreDll.CEGetCommModemStatus(hPort, ref lpModemStat));
    public override bool SetCommMask(IntPtr hPort, CommEventFlags dwEvtMask) => Convert.ToBoolean(CoreDll.CESetCommMask(hPort, dwEvtMask));
    public override bool ReadFile(IntPtr hPort, byte[] buffer, int cbToRead, ref int cbRead, IntPtr lpOverlapped) => Convert.ToBoolean(CoreDll.CEReadFile(hPort, buffer, cbToRead, ref cbRead, IntPtr.Zero));
    public override bool WriteFile(IntPtr hPort, byte[] buffer, int cbToWrite, ref int cbWritten, IntPtr lpOverlapped) => Convert.ToBoolean(CoreDll.CEWriteFile(hPort, buffer, cbToWrite, ref cbWritten, IntPtr.Zero));
    public override bool CloseHandle(IntPtr hPort) => Convert.ToBoolean(CoreDll.CECloseHandle(hPort));
    public override bool SetupComm(IntPtr hPort, int dwInQueue, int dwOutQueue) => Convert.ToBoolean(CoreDll.CESetupComm(hPort, dwInQueue, dwOutQueue));
    public override bool SetCommState(IntPtr hPort, DCB dcb) => Convert.ToBoolean(CoreDll.CESetCommState(hPort, dcb));
    public override bool GetCommState(IntPtr hPort, DCB dcb) => Convert.ToBoolean(CoreDll.CEGetCommState(hPort, dcb));
    public override bool SetCommTimeouts(IntPtr hPort, CommTimeouts timeouts) => Convert.ToBoolean(CoreDll.CESetCommTimeouts(hPort, timeouts));
    public override bool EscapeCommFunction(IntPtr hPort, CommEscapes escape) => Convert.ToBoolean(CoreDll.CEEscapeCommFunction(hPort, (uint)escape));
    public override IntPtr CreateEvent(bool bManualReset, bool bInitialState, string lpName) => CoreDll.CECreateEvent(IntPtr.Zero, Convert.ToInt32(bManualReset), Convert.ToInt32(bInitialState), lpName);
    public override bool SetEvent(IntPtr hEvent) => Convert.ToBoolean(CoreDll.CEEventModify(hEvent, (uint)EventFlags.EVENT_SET));
    public override bool ResetEvent(IntPtr hEvent) => Convert.ToBoolean(CoreDll.CEEventModify(hEvent, (uint)EventFlags.EVENT_RESET));
    public override bool PulseEvent(IntPtr hEvent) => Convert.ToBoolean(CoreDll.CEEventModify(hEvent, (uint)EventFlags.EVENT_PULSE));
    public override int WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds) => CoreDll.CEWaitForSingleObject(hHandle, dwMilliseconds);
    public override bool GetCommProperties(IntPtr hPort, CommCapabilities commcap) => Convert.ToBoolean(CoreDll.CEGetCommProperties(hPort, commcap));
    public override bool FlushFileBuffers(IntPtr hFile) => Convert.ToBoolean(CoreDll.CEFlushFileBuffers(hFile));
  }
}