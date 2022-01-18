using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/5842df8ccbd22792a4000245
  ///   https://www.codewars.com/kata/reviews/5bfd38eeff3986f94c0069db/groups/5dff4529bb26620001623593
  /// </summary>
  public class WriteNumberInExpandedForm
  {
    public static class Kata
    {
      public static string ExpandedForm(long num)
      {
        var ans = new List<string>();

        var str = num.ToString();

        for (var i = 0; i < str.Length; i++)
        {
          if (str[i] == '0')
            continue;

          var sb = new StringBuilder(new string('0', str.Length - i));
          sb[0] = str[i];

          ans.Add(sb.ToString());
        }

        return string.Join(" + ", ans);
      }
    }
  }
}
