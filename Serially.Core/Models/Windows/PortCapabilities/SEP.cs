using System;

namespace Serially.Core.Models.Windows.PortCapabilities
{
  //
  // Serial provider type.
  //
  /// <summary>
  /// SEP enumerates known serial provider types. Currently SERIALCOMM is the only 
  /// provider in this enumeration.
  /// </summary>
  [Flags]
  public enum SEP
  {
    /// <summary>
    /// SERIALCOMM is the only service provider supported by serial APIs.
    /// </summary>
    SEP_SERIALCOMM = 0x00000001
  };
}