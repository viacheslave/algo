using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{

  /// <summary>
  ///   https://www.codewars.com/kata/5552101f47fc5178b1000050
  ///   https://www.codewars.com/kata/reviews/555223eddfa1a05ee100003e/groups/5f8dcfbf56594b0001819c9c
  /// </summary>
  public class DigPow
  {
    public static long digPow(int n, int p)
    {
      var digits = n
        .ToString()
        .ToCharArray()
        .Select(t => int.Parse(t.ToString()))
        .ToArray();

      var num = 0L;
      for (var i = 0; i < digits.Length; i++)
        num += (long)Math.Pow(digits[i], p++);

      if (num % n == 0)
        return num / n;

      return -1;
    }
  }
}
