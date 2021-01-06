using System;
using System.Threading.Tasks;

namespace Serially.Core
{
  public static class ObjectExtensions
  {
    public static void Require<T>(this T value, T expected, Action a)
    {
      if (value.Equals(expected)) { a(); }
    }

    public static async Task RequireAsync<T>(this T value, T expected, Func<Task> a)
    {
      if (value.Equals(expected)) { await a(); }
    }

    public static TRet Require<T, TRet>(this T value, T expected, Func<TRet> a) => value.Equals(expected) ? a() : default;
    public static async Task<TRet> RequireAsync<T, TRet>(this T value, T expected, Func<Task<TRet>> a) => value.Equals(expected) ? await a() : default;
  }
}