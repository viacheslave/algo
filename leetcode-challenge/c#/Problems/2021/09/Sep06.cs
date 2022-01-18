using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/636/week-1-september-1st-september-7th/3965/
  /// 
  /// </summary>
  internal class Sep06
  {
    public class Solution
    {
      public char SlowestKey(int[] releaseTimes, string keysPressed)
      {
        var data = Enumerable
         .Range(0, releaseTimes.Length)
         .Select(r => (time: releaseTimes[r] - (r == 0 ? 0 : releaseTimes[r - 1]), ch: keysPressed[r]))
         .ToList();

        var max = data.Max(x => x.time);

        return data.Where(x => x.time == max)
          .OrderBy(x => x.ch)
          .Select(x => x.ch)
          .Last();
      }
    }
  }
}
