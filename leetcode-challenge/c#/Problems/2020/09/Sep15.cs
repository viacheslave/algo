using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/556/week-3-september-15th-september-21st/3461/
  ///    https://leetcode.com/submissions/detail/395989589/?from=/explore/challenge/card/september-leetcoding-challenge/556/week-3-september-15th-september-21st/3461/  /// </summary>
  internal class Sep15
  {
    public class Solution
    {
      public int LengthOfLastWord(string s)
      {
        var sp = s.Split(new[] { ' ' });

        for (var i = sp.Length - 1; i >= 0; i--)
          if (sp[i] != string.Empty)
            return sp[i].Length;

        return 0;
      }
    }
  }
}
