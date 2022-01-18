namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sum-of-digits-of-string-after-convert/
///    Submission: https://leetcode.com/submissions/detail/528021649/
/// </summary>
internal class P1945
{
  public class Solution
  {
    public int GetLucky(string s, int k)
    {
      var sb = new StringBuilder();

      foreach (var ch in s)
        sb.Append(ch - 97 + 1);

      while (k > 0)
      {
        var sum = sb.ToString().Sum(c => int.Parse(c.ToString()));
        sb = new StringBuilder(sum.ToString());

        k--;
      }

      return int.Parse(sb.ToString());
    }
  }
}
