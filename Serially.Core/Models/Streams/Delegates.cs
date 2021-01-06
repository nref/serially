namespace Serially.Core.Models.Streams
{
  /// <summary>
  /// Represents the method that will handle the event of a SerialPort object.
  /// </summary>
  public delegate void SerialErrorEventHandler(object sender, SerialErrorEventArgs e);

  /// <summary>
  /// Represents the method that will handle the PinChangedEvent event of a SerialPort object.
  /// </summary>
  public delegate void SerialPinChangedEventHandler(object sender, SerialPinChangedEventArgs e);

  /// <summary>
  /// Represents the method that will handle the ReceivedEvent event of a SerialPort object.
  /// </summary>
  public delegate void SerialReceivedEventHandler(object sender, SerialReceivedEventArgs e);
}
