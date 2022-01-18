using System.Collections.Generic;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/572/week-4-december-22nd-december-28th/3581/
  ///    https://leetcode.com/submissions/detail/434743908/?from=explore&item_id=3581
  /// </summary>
  internal class Dec26
  {
    public class Solution
    {
      public int NumDecodings(string s)
      {
        if (string.IsNullOrEmpty(s))
          return 0;

        if (s.Length == 1)
          return s[0] == '0' ? 0 : 1;

        var map = new Dictionary<int, int>()
        {
          [0] = 1,
          [1] = s[s.Length - 1] == '0' ? 0 : 1
        };

        for (var index = s.Length - 2; index >= 0; index--)
        {
          var num = s.Length - index;

          var min1 = map[num - 1];
          var min2 = map[num - 2];

          var count = 0;
          if (s[index] != '0')
            count += min1;

          var two = int.Parse(s.Substring(index, 2));
          if (10 <= two && two <= 26)
            count += min2;

          map[num] = count;
        }

        return map[s.Length];
      }
    }
  }
}
