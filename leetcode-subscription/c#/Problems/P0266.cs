using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/palindrome-permutation/
  ///    Submission: https://leetcode.com/submissions/detail/450988618/
  ///    Facebook, Microsoft
  /// </summary>
  internal class P0266
  {
    public class Solution
    {
      public bool CanPermutePalindrome(string s)
      {
        var map = s
          .GroupBy(d => d)
          .Where(d => d.Count() % 2 == 1)
          .ToDictionary(c => c.Key, c => c.Count());

        return map.Count <= 1;
      }
    }
  }
}
