using System.Collections.Generic;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/569/week-1-december-1st-december-7th/3555/
  ///    https://leetcode.com/submissions/detail/427372844/?from=explore&item_id=3555
  /// </summary>
  internal class Dec05
  {
    public class Solution
    {
      public bool CanPlaceFlowers(int[] flowerbed, int n)
      {
        var prev = -2;
        var count = 0;

        for (var i = 0; i < flowerbed.Length; i++)
        {
          if (flowerbed[i] == 0)
            continue;

          if (i - prev >= 4)
          {
            count += ((i - prev) - 2) / 2;
          }

          prev = i;
        }

        if (flowerbed.Length + 1 - prev >= 4)
        {
          count += ((flowerbed.Length + 1 - prev) - 2) / 2;
        }

        return n <= count;
      }
    }
  }
}
