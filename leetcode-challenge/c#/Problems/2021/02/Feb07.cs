using System;
using System.Collections.Generic;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3631/
  ///    https://leetcode.com/submissions/detail/453140839/?from=explore&item_id=3631
  /// </summary>
  internal class Feb07
  {
    public class Solution
    {
      public int[] ShortestToChar(string S, char C)
      {
        var exact = new List<int>();

        for (var i = 0; i < S.Length; i++)
        {
          if (C == S[i])
            exact.Add(i);
        }

        var res = new int[S.Length];
        var pass = -1;

        for (var i = 0; i < S.Length; i++)
        {
          if (i < exact[0])
          {
            res[i] = Math.Abs(i - exact[0]);
            continue;
          }

          if (i > exact[exact.Count - 1])
          {
            res[i] = Math.Abs(i - exact[exact.Count - 1]);
            continue;
          }

          if (S[i] == C)
          {
            pass++;
            res[i] = 0;
            continue;
          }

          res[i] = Math.Min(
              Math.Abs(i - exact[pass]),
              Math.Abs(exact[pass + 1] - i));
        }

        return res;
      }
    }
  }
}
