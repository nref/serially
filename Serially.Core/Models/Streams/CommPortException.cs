using System;

namespace Serially.Core.Models.Streams
{
  public class CommPortException : Exception
  {
    public CommPortException(string desc) : base(desc) { }
  }
}
