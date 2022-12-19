namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-value-of-a-string-in-an-array/
///    Submission: https://leetcode.com/problems/maximum-value-of-a-string-in-an-array/submissions/859349835/
/// </summary>
internal class P2496
{
  public class Solution
  {
    public int MaximumValue(string[] strs)
    {
      var ans = 0;

      foreach (var str in strs)
      {
        ans = Math.Max(ans,
            str.All(c => Char.IsDigit(c)) ? int.Parse(str) : str.Length);
      }

      return ans;
    }
  }
}
