using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3656/
  /// 
  /// </summary>
  internal class MarWeek1
  {
    public class Solution
    {
      public int CalculateTime(string keyboard, string word)
      {
        var kk = keyboard.Select((k, i) => (k, i)).ToDictionary(k => k.k, k => k.i);

        var ans = kk[word[0]];

        for (var i = 1; i < word.Length; i++)
          ans += Math.Abs(kk[word[i]] - kk[word[i - 1]]);

        return ans;
      }
    }
  }
}
