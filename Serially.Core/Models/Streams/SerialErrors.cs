using System;
using System.ComponentModel;

namespace Serially.Core.Models.Streams
{
  [Flags]
  public enum SerialErrors
  {
    /// <summary>
    /// An input buffer overflow has occurred. There is either no room in the input buffer,
    /// or a character was received after the end-of-file (EOF) character.
    /// </summary>
    [Description("Receive Overflow")] RxOver = 1,

    /// <summary>
    /// A character-buffer overrun has occurred. The next character is lost.
    /// </summary>
    [Description("Buffer Overrun")] Overrun = 2,

    /// <summary>
    /// The hardware detected a parity error.
    /// </summary>
    [Description("Parity Error")] RxParity = 4,

    /// <summary>
    /// The hardware detected a framing error.
    /// </summary>
    [Description("Framing Error")] Frame = 8,

    /// <summary>
    /// The application tried to transmit a character, but the output buffer was full.
    /// </summary>
    [Description("Transmit Full")] TxFull = 256,
  }
}
