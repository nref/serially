using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace Serially.Core.Models.Windows
{
  [StructLayout(LayoutKind.Sequential)]
  public class CommStat
  {
    //
    // typedef struct _COMSTAT {
    //     DWORD fCtsHold : 1;
    //     DWORD fDsrHold : 1;
    //     DWORD fRlsdHold : 1;
    //     DWORD fXoffHold : 1;
    //     DWORD fXoffSent : 1;
    //     DWORD fEof : 1;
    //     DWORD fTxim : 1;
    //     DWORD fReserved : 25;
    //     DWORD cbInQue;
    //     DWORD cbOutQue;
    // } COMSTAT, *LPCOMSTAT;
    //
    private BitVector32 bitfield = new BitVector32(0); // UKI added for CLR bitfield support
    public uint cbInQue = 0;
    public uint cbOutQue = 0;

    // Helper constants for manipulating the bit fields.

    [Flags]
    private enum commFlags
    {
      fCtsHoldMask = 0x01,
      fDsrHoldMask = 0x02,
      fRlsdHoldMask = 0x04,
      fXoffHoldMask = 0x08,
      fXoffSentMask = 0x10,
      fEofMask = 0x20,
      fTximMask = 0x40

    };

    public bool fCtsHold
    {
      get => bitfield[(int)commFlags.fCtsHoldMask];
      set => bitfield[(int)commFlags.fCtsHoldMask] = value;
    }
    public bool fDsrHold
    {
      get => bitfield[(int)commFlags.fDsrHoldMask];
      set => bitfield[(int)commFlags.fDsrHoldMask] = value;
    }
    public bool fRlsdHold
    {
      get => bitfield[(int)commFlags.fRlsdHoldMask];
      set => bitfield[(int)commFlags.fRlsdHoldMask] = value;
    }
    public bool fXoffHold
    {
      get => bitfield[(int)commFlags.fXoffHoldMask];
      set => bitfield[(int)commFlags.fXoffHoldMask] = value;
    }
    public bool fXoffSent
    {
      get => bitfield[(int)commFlags.fXoffSentMask];
      set => bitfield[(int)commFlags.fXoffSentMask] = value;
    }
    public bool fEof
    {
      get => bitfield[(int)commFlags.fEofMask];
      set => bitfield[(int)commFlags.fEofMask] = value;
    }
    public bool fTxim
    {
      get => bitfield[(int)commFlags.fTximMask];
      set => bitfield[(int)commFlags.fTximMask] = value;
    }
  }
}


