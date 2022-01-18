using System;
using System.Collections.Generic;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/515de9ae9dcfc28eb6000001
  ///   https://www.codewars.com/kata/reviews/57ce1bfef17ba36b3500006d/groups/5dff3f674225f30001f55d1e
  /// </summary>
  public class SplitString
  {
    public static string[] Solution(string str)
    {
      var ans = new List<string>();

      for (var i = 0; i < str.Length; i += 2)
      {
        var s = new StringBuilder();
        s.Append(str[i]);

        if (i + 1 == str.Length)
          s.Append('_');
        else
          s.Append(str[i + 1]);

        ans.Add(s.ToString());
      }

      return ans.ToArray();
    }
  }
}
