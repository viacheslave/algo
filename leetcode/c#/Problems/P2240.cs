namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-ways-to-buy-pens-and-pencils/
///    Submission: https://leetcode.com/submissions/detail/684168615/
/// </summary>
internal class P2240
{
  public class Solution
  {
    public long WaysToBuyPensPencils(int total, int cost1, int cost2)
    {
      var maxItem1 = total / cost1;

      var ans = 0L;

      for (var i = 0; i <= maxItem1; i++)
      {
        var left = total - i * cost1;
        ans += (left / cost2) + 1;
      }

      return ans;
    }
  }
}
