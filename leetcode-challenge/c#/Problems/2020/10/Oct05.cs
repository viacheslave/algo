using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3484/
  ///
  /// </summary>
  internal class Oct05
  {
    public class Solution
    {
      public int BitwiseComplement(int N)
      {
        if (N == 0)
          return 1;

        var original = N;
        var power = 0;
        var comp = 0;

        while (true)
        {
          if (power == 31)
            break;

          if (original >= (int)Math.Pow(2, power))
          {
            var digit = N % 2;

            if (digit == 0)
              comp += (int)Math.Pow(2, power);

            N = N >> 1;
            power++;
            continue;
          }
          break;
        }

        return comp;
      }
    }
  }
}
