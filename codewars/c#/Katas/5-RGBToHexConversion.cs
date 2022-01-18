using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/513e08acc600c94f01000001
  ///   https://www.codewars.com/kata/reviews/59956835a82c795f9d000004/groups/5e0510434ebc20000141ff7a
  /// </summary>
  public class RGBToHexConversion
  {
    public class Kata
    {
      public static string Rgb(int r, int g, int b)
      {
        r = Norm(r);
        g = Norm(g);
        b = Norm(b);

        return $"{r:X2}{g:X2}{b:X2}";
      }

      private static int Norm(int b)
      {
        if (b > 255) return 255;
        if (b < 0) return 0;
        return b;
      }
    }
  }
}
