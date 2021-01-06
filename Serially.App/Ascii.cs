using System;
using System.Collections.Generic;

namespace Serially.App
{
  public static class Ascii
  {
    public static readonly char Null = (char)0;
    public static readonly char Esc = (char)27;
    public static readonly char LeftBracket = (char)91;
    public static readonly char Delete = (char)127;

    private static readonly Dictionary<ConsoleKey, char> KeyMap = new Dictionary<ConsoleKey, char>
    {
      [ConsoleKey.Delete] = Delete,
    };

    private static readonly Dictionary<ConsoleKey, char> Escapes = new Dictionary<ConsoleKey, char>
    {
      [ConsoleKey.UpArrow] = 'A',
      [ConsoleKey.DownArrow] = 'B',
      [ConsoleKey.RightArrow] = 'C',
      [ConsoleKey.LeftArrow] = 'D',
    };

    /// <summary>
    /// Map the key key to an ASCII character if possible.
    /// 
    /// <para/>
    /// Return char_null if the given keypress either does not need mapping to an ASCII keycode
    /// or cannot be represented with a single ASCII character, in which case it should be escaped.
    /// 
    /// <para/>
    /// e.g. ConsoleKey 'A' == 65 and 65 is ASCII for 'A', 
    /// but ConsoleKey 'Delete' == 46 which should be 127 in ASCII.
    /// </summary>
    public static char Map(ConsoleKey key) => KeyMap.TryGetValue(key, out char value) ? value : Null;

    /// <summary>
    /// Return char_null if the given keypress is not representable as an ASCII escape sequence.
    /// Else return the character which when prefixed by "ESC[" communicates the given keypress 
    /// </summary>
    public static char Escape(ConsoleKey key) => Escapes.TryGetValue(key, out char value) ? value : Null;

    public static char[] Map(ConsoleKeyInfo info)
    {
      char escaped = Escape(info.Key);
      if (escaped != Null)
      {
        return new[] { Esc, LeftBracket, escaped };
      }

      char mapped = Map(info.Key);
      return new[] { mapped != Null ? mapped : info.KeyChar };
    }
  }
}
