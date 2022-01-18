using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3411/
  ///    https://leetcode.com/submissions/detail/375347650/?from=/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3411/
  /// </summary>
  internal class Aug03
  {
    public class Solution
    {
      public bool IsPalindrome(string s)
      {
        var arr = s.ToLower().Where(ch => char.IsLetterOrDigit(ch)).ToArray();

        for (var i = 0; i < arr.Length / 2; ++i)
          if (arr[i] != arr[arr.Length - 1 - i])
            return false;

        return true;
      }
    }
  }
}
