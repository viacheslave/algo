using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3423/
  ///    https://leetcode.com/submissions/detail/380696258/?from=/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3423/
  /// </summary>
  internal class Aug14
  {
    public class Solution
    {
      public int LongestPalindrome(string s)
      {
        var di = new Dictionary<char, int>();

        foreach (var ch in s)
        {
          if (!di.ContainsKey(ch))
            di[ch] = 0;
          di[ch]++;
        }

        var count = di.Select(_ => _.Value / 2).Sum() * 2;
        var central = di.Any(_ => _.Value % 2 == 1);

        if (central)
          count++;

        return count;
      }
    }
  }
}
