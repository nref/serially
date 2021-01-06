using System;
using System.Threading.Tasks;

namespace Serially.Core
{
  public static class BooleanExtensions
  {
    public static void Require(this bool value, bool expected, Action a)
    {
      if (value == expected) { a(); }
    }

    public static async Task RequireAsync(this bool value, bool expected, Func<Task> a)
    {
      if (value == expected) { await a(); }
    }

    public static T Require<T>(this bool value, bool expected, Func<T> a) => value == expected ? a() : default;
    public static async Task<T> RequireAsync<T>(this bool value, bool expected, Func<Task<T>> a) => value == expected ? await a() : default;
  }
}