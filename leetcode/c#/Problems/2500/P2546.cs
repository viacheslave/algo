namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/apply-bitwise-operations-to-make-strings-equal/
///    Submission: https://leetcode.com/problems/apply-bitwise-operations-to-make-strings-equal/submissions/901877004/
/// </summary>
internal class P2546
{
  public class Solution
  {
    public bool MakeStringsEqual(string s, string target)
    {
      var sZeroes = s.Count(c => c == '0');
      var tZeroes = target.Count(c => c == '0');

      // s all zeroes
      if (sZeroes == s.Length)
      {
        // target needs to be all zeroes
        return tZeroes == target.Length;
      }

      return tZeroes < target.Length;
    }
  }
}
