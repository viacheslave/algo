namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-uncommon-subsequence-i/
///    Submission: https://leetcode.com/submissions/detail/237987697/
/// </summary>
internal class P0521
{
  public class Solution
  {
    public int FindLUSlength(string a, string b)
    {
      return a == b ? -1 : Math.Max(a.Length, b.Length);
    }
  }
}
