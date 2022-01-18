using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3839/
  /// 
  /// </summary>
  internal class Aug06
  {
    public class Solution
    {
      public bool StoneGame(int[] piles)
      {
        //[5,3,4,5]
        //[3,7,2,3]
        var mem = new Dictionary<(int, int), int>();
        var res = Get(piles, 0, piles.Length - 1, mem);

        var other = piles.Sum() - res;
        return res > other;
      }

      private int Get(int[] piles, int left, int right, Dictionary<(int, int), int> mem)
      {
        if (left == right)
          return piles[left];

        if (right - left == 1)
          return Math.Max(piles[left], piles[right]);

        if (mem.ContainsKey((left, right)))
          return mem[(left, right)];

        var leftcase = piles[left] + Math.Min(
            Get(piles, left + 1, right - 1, mem),
            Get(piles, left + 2, right, mem));

        var rightcase = piles[right] + Math.Min(
            Get(piles, left, right - 2, mem),
            Get(piles, left + 1, right - 1, mem));

        mem[(left, right)] = Math.Max(leftcase, rightcase);
        return mem[(left, right)];
      }
    }
  }
}
