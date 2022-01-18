using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/3968/
  /// 
  /// </summary>
  internal class Sep08
  {
    public class Solution
    {
      public string ShiftingLetters(string S, int[] shifts)
      {
        for (var i = shifts.Length - 1; i >= 0; i--)
          shifts[i] = (shifts[i] + ((i == shifts.Length - 1) ? 0 : (shifts[i + 1] % 26))) % 26;

        var sb = new StringBuilder(S);

        for (int i = 0; i < shifts.Length; i++)
        {
          sb[i] = (char)(((shifts[i] + ((int)sb[i]) - 97) % 26) + 97);
        }

        return sb.ToString();
      }
    }
  }
}
