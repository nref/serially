namespace Serially.Core.Models.Windows
{
  /// <summary>
  /// Error values from serial API calls
  /// </summary>
  public enum APIErrors : int
  {
    /// <summary>
    /// Port not found
    /// </summary>
    ERROR_FILE_NOT_FOUND = 2,
    /// <summary>
    /// Invalid port name
    /// </summary>
    ERROR_INVALID_NAME = 123,
    /// <summary>
    /// Access denied
    /// </summary>
    ERROR_ACCESS_DENIED = 5,
    /// <summary>
    /// invalid handle
    /// </summary>
    ERROR_INVALID_HANDLE = 6,
    /// <summary>
    /// IO pending
    /// </summary>
    ERROR_IO_PENDING = 997
  }
}