using Serially.Core.Models.Windows;
using System;
using System.Runtime.InteropServices;

namespace Serially.Core.Infrastructure.Pinvoke
{
  public static class CoreDll
  {
    [DllImport("coredll.dll", EntryPoint = "WaitForSingleObject", SetLastError = true)]
    public static extern int CEWaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

    [DllImport("coredll.dll", EntryPoint = "EventModify", SetLastError = true)]
    public static extern int CEEventModify(IntPtr hEvent, uint function);

    [DllImport("coredll.dll", EntryPoint = "CreateEvent", SetLastError = true)]
    public static extern IntPtr CECreateEvent(IntPtr lpEventAttributes, int bManualReset, int bInitialState, string lpName);

    [DllImport("coredll.dll", EntryPoint = "EscapeCommFunction", SetLastError = true)]
    public static extern int CEEscapeCommFunction(IntPtr hFile, uint dwFunc);

    [DllImport("coredll.dll", EntryPoint = "SetCommTimeouts", SetLastError = true)]
    public static extern int CESetCommTimeouts(IntPtr hFile, CommTimeouts timeouts);

    [DllImport("coredll.dll", EntryPoint = "GetCommState", SetLastError = true)]
    public static extern int CEGetCommState(IntPtr hFile, DCB dcb);

    [DllImport("coredll.dll", EntryPoint = "SetCommState", SetLastError = true)]
    public static extern int CESetCommState(IntPtr hFile, DCB dcb);

    [DllImport("coredll.dll", EntryPoint = "SetupComm", SetLastError = true)]
    public static extern int CESetupComm(IntPtr hFile, int dwInQueue, int dwOutQueue);

    [DllImport("coredll.dll", EntryPoint = "CloseHandle", SetLastError = true)]
    public static extern int CECloseHandle(IntPtr hObject);

    [DllImport("coredll.dll", EntryPoint = "WriteFile", SetLastError = true)]
    public static extern int CEWriteFile(IntPtr hFile, byte[] lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, IntPtr lpOverlapped);

    [DllImport("coredll.dll", EntryPoint = "ReadFile", SetLastError = true)]
    public static extern int CEReadFile(IntPtr hFile, byte[] lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, IntPtr lpOverlapped);

    [DllImport("coredll.dll", EntryPoint = "SetCommMask", SetLastError = true)]
    public static extern int CESetCommMask(IntPtr handle, CommEventFlags dwEvtMask);

    [DllImport("coredll.dll", EntryPoint = "GetCommModemStatus", SetLastError = true)]
    public static extern int CEGetCommModemStatus(IntPtr hFile, ref uint lpModemStat);

    [DllImport("coredll.dll", EntryPoint = "ClearCommError", SetLastError = true)]
    public static extern int CEClearCommError(IntPtr hFile, ref CommErrorFlags lpErrors, CommStat lpStat);

    [DllImport("coredll.dll", EntryPoint = "WaitCommEvent", SetLastError = true)]
    public static extern int CEWaitCommEvent(IntPtr hFile, ref CommEventFlags lpEvtMask, IntPtr lpOverlapped);

    [DllImport("coredll.dll", EntryPoint = "CreateFileW", SetLastError = true)]
    public static extern IntPtr CECreateFileW(
        string lpFileName, uint dwDesiredAccess, uint dwShareMode,
        IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes,
        IntPtr hTemplateFile);

    [DllImport("coredll.dll", EntryPoint = "GetCommProperties", SetLastError = true)]
    public static extern int CEGetCommProperties(IntPtr hFile, CommCapabilities commcap);

    [DllImport("coredll.dll", EntryPoint = "FlushFileBuffers", SetLastError = true)]
    public static extern int CEFlushFileBuffers(IntPtr hFile);
  }
}
