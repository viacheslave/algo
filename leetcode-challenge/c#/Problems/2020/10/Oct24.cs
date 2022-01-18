using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3506/
  ///    https://leetcode.com/submissions/detail/412532520/?from=/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3506/
  /// </summary>
  internal class Oct24
  {
    public class Solution
    {
      public int BagOfTokensScore(int[] tokens, int P)
      {
        if (tokens.Length == 0)
          return 0;

        Array.Sort(tokens);

        if (P < tokens[0])
          return 0;

        var left = 0;
        var right = tokens.Length - 1;
        var points = 0;
        var maxPoints = int.MinValue;

        while (left <= right)
        {
          while (left <= right && P >= tokens[left])
          {
            P -= tokens[left];

            left++;
            points++;

            maxPoints = Math.Max(maxPoints, points);
          }

          while (left <= right && P < tokens[left])
          {
            P += tokens[right];

            right--;
            points--;
          }
        }

        return maxPoints;
      }
    }
  }
}
