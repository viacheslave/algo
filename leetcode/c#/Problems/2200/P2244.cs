namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-rounds-to-complete-all-tasks/
///    Submission: https://leetcode.com/submissions/detail/682273548/
/// </summary>
internal class P2244
{
  public class Solution
  {
    public int MinimumRounds(int[] tasks)
    {
      var values = tasks.GroupBy(x => x).Select(x => x.Count())
        .ToList();

      var ans = 0;

      foreach (var value in values)
      {
        if (value == 1)
          return -1;

        if (value % 3 == 0)
        {
          ans += value / 3;
          continue;
        }

        if (value % 3 == 2)
        {
          ans += (value - 2) / 3 + 1;
          continue;
        }

        ans += (value - 4) / 3 + 2;
      }

      return ans == 0 ? -1 : ans;
    }
  }
}
