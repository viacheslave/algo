using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/599/week-2-may-8th-may-14th/3739/
  /// 
  /// </summary>
  internal class May11
  {
    public class Solution
    {
      public int MaxScore(int[] cardPoints, int k)
      {
        var windowLength = cardPoints.Length - k;
        var sum = cardPoints.Sum();

        var currentSum = cardPoints.Take(windowLength).Sum();
        var ans = currentSum;

        // min
        for (var start = 1; start <= cardPoints.Length - windowLength; start++)
        {
          currentSum = currentSum - cardPoints[start - 1] + cardPoints[start + windowLength - 1];
          ans = Math.Min(ans, currentSum);
        }

        return sum - ans;
      }
    }
  }
}
