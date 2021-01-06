using Serially.Core.Models.Windows;
using System;
using System.Runtime.InteropServices;

namespace Serially.Core.Infrastructure.Pinvoke
{
  public static class Kernel32
  {
    [DllImport("kernel32", EntryPoint = "LocalAlloc", SetLastError = true)]
    public static extern IntPtr LocalAlloc(int uFlags, int uBytes);

    [DllImport("kernel32", EntryPoint = "LocalFree", SetLastError = true)]
    public static extern IntPtr LocalFree(IntPtr hMem);

    [DllImport("kernel32.dll")]
    public static extern void SetLastError(uint dwErrCode);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern uint QueryDosDevice(
        [MarshalAs(UnmanagedType.LPTStr)] string lpDeviceName,
        [MarshalAs(UnmanagedType.LPTStr)] string lpTargetPath,
        uint ucchMax);


    [DllImport("kernel32.dll", EntryPoint = "WaitForSingleObject", SetLastError = true)]
    public static extern int WinWaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

    [DllImport("kernel32.dll", EntryPoint = "SetEvent", SetLastError = true)]
    public static extern int WinSetEvent(IntPtr hEvent);

    [DllImport("kernel32.dll", EntryPoint = "ResetEvent", SetLastError = true)]
    public static extern int WinResetEvent(IntPtr hEvent);

    [DllImport("kernel32.dll", EntryPoint = "PulseEvent", SetLastError = true)]
    public static extern int WinPulseEvent(IntPtr hEvent);

    [DllImport("kernel32.dll", EntryPoint = "CreateEvent", SetLastError = true)]
    public static extern IntPtr WinCreateEvent(IntPtr lpEventAttributes, int bManualReset, int bInitialState, string lpName);

    [DllImport("kernel32.dll", EntryPoint = "EscapeCommFunction", SetLastError = true)]
    public static extern int WinEscapeCommFunction(IntPtr hFile, uint dwFunc);

    [DllImport("kernel32.dll", EntryPoint = "SetCommTimeouts", SetLastError = true)]
    public static extern int WinSetCommTimeouts(IntPtr hFile, CommTimeouts timeouts);

    [DllImport("kernel32.dll", EntryPoint = "GetCommState", SetLastError = true)]
    public static extern int WinGetCommState(IntPtr hFile, DCB dcb);

    [DllImport("kernel32.dll", EntryPoint = "SetCommState", SetLastError = true)]
    public static extern int WinSetCommState(IntPtr hFile, DCB dcb);

    [DllImport("kernel32.dll", EntryPoint = "SetupComm", SetLastError = true)]
    public static extern int WinSetupComm(IntPtr hFile, int dwInQueue, int dwOutQueue);

    [DllImport("kernel32.dll", EntryPoint = "CloseHandle", SetLastError = true)]
    public static extern int WinCloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", EntryPoint = "WriteFile", SetLastError = true)]
    public static extern int WinWriteFile(IntPtr hFile, byte[] lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, IntPtr lpOverlapped);

    [DllImport("kernel32.dll", EntryPoint = "ReadFile", SetLastError = true)]
    public static extern int WinReadFile(IntPtr hFile, byte[] lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, IntPtr lpOverlapped);

    [DllImport("kernel32.dll", EntryPoint = "SetCommMask", SetLastError = true)]
    public static extern int WinSetCommMask(IntPtr handle, CommEventFlags dwEvtMask);

    [DllImport("kernel32.dll", EntryPoint = "GetCommModemStatus", SetLastError = true)]
    public static extern int WinGetCommModemStatus(IntPtr hFile, ref uint lpModemStat);

    [DllImport("kernel32.dll", EntryPoint = "ClearCommError", SetLastError = true)]
    public static extern int WinClearCommError(IntPtr hFile, ref CommErrorFlags lpErrors, CommStat lpStat);

    [DllImport("kernel32.dll", EntryPoint = "CreateFileW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr WinCreateFileW(string lpFileName, uint dwDesiredAccess, uint dwShareMode,
        IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes,
        IntPtr hTemplateFile);

    [DllImport("kernel32.dll", EntryPoint = "WaitCommEvent", SetLastError = true)]
    public static extern int WinWaitCommEvent(IntPtr hFile, ref CommEventFlags lpEvtMask, IntPtr lpOverlapped);

    [DllImport("kernel32.dll", EntryPoint = "GetCommProperties", SetLastError = true)]
    public static extern int WinGetCommProperties(IntPtr hFile, CommCapabilities commcap);

    [DllImport("kernel32.dll", EntryPoint = "FlushFileBuffers", SetLastError = true)]
    public static extern bool WinFlushFileBuffers(IntPtr hFile);
  }
}
