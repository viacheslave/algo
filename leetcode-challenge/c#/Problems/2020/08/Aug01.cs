using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3409/
  ///    https://leetcode.com/submissions/detail/374436782/?from=/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3409/
  /// </summary>
  internal class Aug01
  {
    public class Solution
    {
      public bool DetectCapitalUse(string word)
      {
        var uppers = new List<int>();

        for (int i = 0; i < word.Length; i++)
        {
          if (char.IsUpper(word[i]))
            uppers.Add(i);
        }

        if (uppers.Count == 0)
          return true;

        if (uppers.Count == word.Length)
          return true;

        if (uppers.Count == 1 && uppers[0] == 0)
          return true;

        return false;
      }
    }
  }
}
