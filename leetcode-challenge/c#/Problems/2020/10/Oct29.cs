using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/563/week-5-october-29th-october-31st/3512/
  ///    https://leetcode.com/submissions/detail/414469558/?from=/explore/challenge/card/october-leetcoding-challenge/563/week-5-october-29th-october-31st/3512/
  /// </summary>
  internal class Oct29
  {
    public class Solution
    {
      public int MaxDistToClosest(int[] seats)
      {
        var d = new Dictionary<int, int>();

        var start = -1;
        for (var i = 0; i < seats.Length; i++)
        {
          if (seats[i] == 1)
          {
            start = i;
            d[start] = 0;
          }
          else if (start != -1)
          {
            d[start]++;
          }
        }

        var left = d.OrderBy(_ => _.Key).First().Key;
        if (left > 0)
          d[-left] = left * 2 - 1;

        var right = d.OrderByDescending(_ => _.Key).First().Key;
        if (right < seats.Length - 1)
          d[right] += (seats.Length - 1 - right);

        var personItem = d.OrderByDescending(_ => _.Value).First();
        return (personItem.Value + 1) / 2;
      }
    }
  }
}
