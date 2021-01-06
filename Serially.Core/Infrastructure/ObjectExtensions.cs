using System;
using System.Threading.Tasks;

namespace Serially.Core.Infrastructure
{
  public static class ObjectExtensions
  {
    public static void If<T>(this T value, T expected, Action a)
    {
      if (value.Equals(expected)) { a(); }
    }

    public static async Task IfAsync<T>(this T value, T expected, Func<Task> a)
    {
      if (value.Equals(expected)) { await a(); }
    }

    public static TRet If<T, TRet>(this T value, T expected, Func<TRet> a) => value.Equals(expected) ? a() : default;
    public static async Task<TRet> IfAsync<T, TRet>(this T value, T expected, Func<Task<TRet>> a) => value.Equals(expected) ? await a() : default;
  }
}