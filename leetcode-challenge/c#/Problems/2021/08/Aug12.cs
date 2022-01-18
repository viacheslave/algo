using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/614/week-2-august-8th-august-14th/3887/
  /// 
  /// </summary>
  internal class Aug10
  {
    public class Solution
    {
      public int MinFlipsMonoIncr(string S)
      {
        var totalOnes = S.Count(x => x == '1');

        if (totalOnes == S.Length || totalOnes == 0)
          return 0;

        // calculate number of ones up to centain index
        var preOnes = new int[S.Length + 1];
        for (var i = 0; i < S.Length; i++)
          preOnes[i + 1] = S[i] == '1' ? preOnes[i] + 1 : preOnes[i];

        var ans = int.MaxValue;

        for (var i = 0; i < S.Length + 1; i++)
        {
          var onesLeft = preOnes[i];
          var onesRight = totalOnes - onesLeft;

          // for every left and right substring:
          // answer is the sum of ones on the left (to be converted to zeros)
          // plus the sum of zeros on the right (to be converted to ones)
          // in order to make is monotone increasing.
          ans = Math.Min(ans,
            onesLeft + (S.Length - i - onesRight));
        }

        return ans;
      }
    }
  }
}
