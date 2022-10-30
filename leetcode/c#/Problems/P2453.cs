namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/destroy-sequential-targets/
///    Submission: https://leetcode.com/problems/destroy-sequential-targets/submissions/832793168/
/// </summary>
internal class P2453
{
  public class Solution
  {
    public int DestroyTargets(int[] nums, int space)
    {
      // mod space gives grouped elements

      return nums.Select(n => (n: n, mod: n % space))
        .GroupBy(b => b.mod)
        .Select(b => (count: b.Count(), min: b.Min().n))
        .OrderByDescending(b => b.count)
        .ThenBy(b => b.min)
        .First()
        .min;
    }
  }

}
