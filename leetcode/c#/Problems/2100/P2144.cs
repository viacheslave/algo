namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-cost-of-buying-candies-with-discount/
///    Submission: https://leetcode.com/submissions/detail/625280231/
/// </summary>
/// <remarks>
///   Greedy. Buy two most expensive candies and get next most expensive for free.
/// </remarks>
internal class P2144
{
  public class Solution
  {
    public int MinimumCost(int[] cost)
    {
      Array.Sort(cost);

      var ans = 0;

      for (int i = cost.Length - 1; i >= 0; i -= 3)
      {
        ans += cost[i];

        if (i - 1 >= 0)
        {
          ans += cost[i - 1];
        }
      }

      return ans;
    }
  }
}
