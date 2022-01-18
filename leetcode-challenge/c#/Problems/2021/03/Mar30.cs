using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/592/week-5-march-29th-march-31st/3690/
  ///   https://leetcode.com/submissions/detail/474187854/?from=explore&item_id=3690
  /// </summary>
  internal class Mar30
  {
    public class Solution
    {
      public int MaxEnvelopes(int[][] envelopes)
      {
        envelopes = envelopes.OrderBy(_ => _[0]).ThenBy(_ => _[1]).ToArray();

        if (envelopes.Length == 0)
          return 0;

        var lis = new Dictionary<int, int>();

        for (int i = 0; i < envelopes.Length; i++)
        {
          var maxLength = 1;

          for (int j = 0; j < i; j++)
          {
            if (envelopes[j][0] < envelopes[i][0] && envelopes[j][1] < envelopes[i][1])
            {
              maxLength = Math.Max(maxLength, lis[j] + 1);
            }
          }

          lis[i] = maxLength;
        }

        return lis.Max(_ => _.Value);
      }
    }
  }
}
