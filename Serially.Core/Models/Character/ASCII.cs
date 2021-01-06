namespace Serially.Core.Models.Character
{
  /// <summary>
  /// Common ASCII Control Codes
  /// </summary>
  public enum ASCII : byte
  {
    /// <summary>
    /// NULL
    /// </summary>
    NULL = 0x00,
    /// <summary>
    /// Start of Heading
    /// </summary>
    SOH = 0x01,
    /// <summary>
    /// Start of Text
    /// </summary>
    STX = 0x02,
    /// <summary>
    /// End of Text
    /// </summary>
    ETX = 0x03,
    /// <summary>
    /// End of Transmission
    /// </summary>
    EOT = 0x04,
    /// <summary>
    /// Enquiry
    /// </summary>
    ENQ = 0x05,
    /// <summary>
    /// Acknowledge
    /// </summary>
    ACK = 0x06,
    /// <summary>
    /// Bell
    /// </summary>
    BELL = 0x07,
    /// <summary>
    /// Backspace
    /// </summary>
    BS = 0x08,
    /// <summary>
    /// Horizontal tab
    /// </summary>
    HT = 0x09,
    /// <summary>
    /// Line Feed
    /// </summary>
    LF = 0x0A,
    /// <summary>
    /// Vertical tab
    /// </summary>
    VT = 0x0B,
    /// <summary>
    /// Form Feed
    /// </summary>
    FF = 0x0C,
    /// <summary>
    /// Carriage Return
    /// </summary>
    CR = 0x0D,
    /// <summary>
    /// Shift out
    /// </summary>
    SO = 0x0E,
    /// <summary>
    /// Shift in
    /// </summary>
    SI = 0x0F,
    /// <summary>
    /// Device Control 1
    /// </summary>
    DC1 = 0x11,
    /// <summary>
    /// Device Control 2
    /// </summary>
    DC2 = 0x12,
    /// <summary>
    /// Device Control 3
    /// </summary>
    DC3 = 0x13,
    /// <summary>
    /// Device Control 4
    /// </summary>
    DC4 = 0x14,
    /// <summary>
    /// No Acknowledge
    /// </summary>
    NAK = 0x15,
    /// <summary>
    /// Synchronization
    /// </summary>
    SYN = 0x16,
    /// <summary>
    /// End of Transmission Block
    /// </summary>
    ETB = 0x17,
    /// <summary>
    /// Cancel
    /// </summary>
    CAN = 0x18,
    /// <summary>
    /// End of Medium
    /// </summary>
    EM = 0x19,
    /// <summary>
    /// Substitute Character
    /// </summary>
    SUB = 0x1A,
    /// <summary>
    /// Escape
    /// </summary>
    ESC = 0x1B,
    /// <summary>
    /// Field Separator
    /// </summary>
    FS = 0x1C,
    /// <summary>
    /// Group Separator
    /// </summary>
    GS = 0x1D,
    /// <summary>
    /// Record Separator
    /// </summary>
    RS = 0x1E,
    /// <summary>
    /// Unit Separator
    /// </summary>
    US = 0x1F,
    /// <summary>
    /// Spare
    /// </summary>
    SP = 0x20,
    /// <summary>
    /// Left/Opening Bracket [
    /// </summary>
    LeftBracket = 0x5B,
    /// <summary>
    /// Delete
    /// </summary>
    DEL = 0x7F
  }
}
