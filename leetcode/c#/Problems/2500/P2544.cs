namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/alternating-digit-sum/
///    Submission: https://leetcode.com/problems/alternating-digit-sum/submissions/901878538/
/// </summary>
internal class P2544
{
  public class Solution
  {
    public int AlternateDigitSum(int n)
    {
      var digits = n.ToString()
        .Select(c => int.Parse(c.ToString())).ToList();

      return digits.Select((n, i) => (i % 2 == 0 ? n : -n)).Sum();
    }
  }
}
