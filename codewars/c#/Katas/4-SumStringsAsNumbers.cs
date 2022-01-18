using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/5324945e2ece5e1f32000370
  ///   https://www.codewars.com/kata/reviews/553a8610f3cc94c5e40000cb/groups/5e00fc908c89df00016742df
  /// </summary>
  public class SumStringsAsNumbers
  {
    public static class Kata
    {
      public static string sumStrings(string a, string b)
      {
        var i1 = a.Length - 1;
        var i2 = b.Length - 1;

        StringBuilder sb = new StringBuilder();

        bool carry = false;

        while (i1 >= 0 || i2 >= 0)
        {
          var n1 = (i1 >= 0) ? int.Parse(a[i1].ToString()) : 0;
          var n2 = (i2 >= 0) ? int.Parse(b[i2].ToString()) : 0;

          var s = n1 + n2;
          if (carry)
            s++;

          if (s >= 10)
            carry = true;
          else
            carry = false;

          sb.Insert(0, (s % 10).ToString());

          i1--;
          i2--;
        }

        if (carry)
          sb.Insert(0, "1");

        return sb.ToString().TrimStart('0');
      }
    }
  }
}
