using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/single-row-keyboard/
  ///    Submission: https://leetcode.com/submissions/detail/451210384/
  ///    Google
  /// </summary>
  internal class P1165
  {
    public class Solution
    {
      public int CalculateTime(string keyboard, string word)
      {
        var kk = keyboard.Select((k, i) => (k, i)).ToDictionary(k => k.k, k => k.i);

        var ans = kk[word[0]];

        for (var i = 1; i < word.Length; i++)
          ans += Math.Abs(kk[word[i]] - kk[word[i - 1]]);

        return ans;
      }
    }
  }
}
