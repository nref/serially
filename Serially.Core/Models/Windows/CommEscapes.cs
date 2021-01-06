namespace Serially.Core.Models.Windows
{
  /// <summary>
  /// Communication escapes
  /// </summary>
  public enum CommEscapes : uint
  {
    /// <summary>
    /// Causes transmission to act as if an XOFF character has been received.
    /// </summary>
    SETXOFF = 1,
    /// <summary>
    /// Causes transmission to act as if an XON character has been received.
    /// </summary>
    SETXON = 2,
    /// <summary>
    /// Sends the RTS (Request To Send) signal.
    /// </summary>
    SETRTS = 3,
    /// <summary>
    /// Clears the RTS (Request To Send) signal
    /// </summary>
    CLRRTS = 4,
    /// <summary>
    /// Sends the DTR (Data Terminal Ready) signal.
    /// </summary>
    SETDTR = 5,
    /// <summary>
    /// Clears the DTR (Data Terminal Ready) signal.
    /// </summary>
    CLRDTR = 6,
    /// <summary>
    /// Suspends character transmission and places the transmission line in a break state until the ClearCommBreak function is called (or EscapeCommFunction is called with the CLRBREAK extended function code). The SETBREAK extended function code is identical to the SetCommBreak function. This extended function does not flush data that has not been transmitted.
    /// </summary>
    SETBREAK = 8,
    /// <summary>
    /// Restores character transmission and places the transmission line in a nonbreak state. The CLRBREAK extended function code is identical to the ClearCommBreak function
    /// </summary>
    CLRBREAK = 9,
    ///Set the port to IR mode.
    SETIR = 10,
    /// <summary>
    /// Set the port to non-IR mode.
    /// </summary>
    CLRIR = 11
  }
}