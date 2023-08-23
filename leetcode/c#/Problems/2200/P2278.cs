namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/percentage-of-letter-in-string/
///    Submission: https://leetcode.com/submissions/detail/705322585/
/// </summary>
internal class P2278
{
  public class Solution
  {
    public int PercentageLetter(string s, char letter)
    {
      return (int)Math.Floor(100d * s.Count(ch => ch == letter) / s.Length);
    }
  }
}
