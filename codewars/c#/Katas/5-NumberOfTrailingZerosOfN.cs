using System;
using System.Collections.Generic;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/52f787eb172a8b4ae1000a34
  ///   https://www.codewars.com/kata/reviews/59b794bc62a4af4593001bf9/groups/5dff479cbb266200016235ac
  /// </summary>
  public class NumberOfTrailingZerosOfN
  {
    public static class Kata
    {
      public static int TrailingZeros(int n)
      {
        int fives = 0;

        while (n > 0)
        {
          fives += n / 5;
          n = n / 5;
        }

        return fives;
      }

      private static int GetZeros(int n, int div)
      {
        int val = 0;
        while (n % div == 0)
        {
          val++;
          n = n / div;
        }
        return val;
      }
    }
  }
}
