using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3668/
  ///   
  /// </summary>
  internal class Mar11
  {
    public class Solution
    {
      public int CoinChange(int[] coins, int amount)
      {
        var map = new Dictionary<int, int>();
        map[0] = 0;

        for (var i = 1; i <= amount; i++)
        {
          var min = int.MaxValue;
          for (var j = 0; j < coins.Length; j++)
          {
            if (i - coins[j] >= 0)
            {
              var mapValue = map[i - coins[j]];
              if (mapValue != int.MaxValue)
              {
                min = Math.Min(min, mapValue + 1);
              }
            }
          }

          map[i] = min;
        }

        return map[amount] == int.MaxValue ? -1 : map[amount];
      }
    }
  }
}
