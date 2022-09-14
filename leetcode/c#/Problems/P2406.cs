namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/divide-intervals-into-minimum-number-of-groups/
///    Submission: https://leetcode.com/submissions/detail/797389981/
/// </summary>
internal class P2406
{
  public class Solution
  {
    public int MinGroups(int[][] intervals)
    {
      var arr = intervals
        .SelectMany(i => new[] { (i[0], 1), (i[1] + 1, -1) })
        .OrderBy(i => i.Item1)
        .ThenBy(i => i.Item2)
        .ToArray();

      var cur = 0;
      var ans = 0;

      foreach (var item in arr)
      {
        if (item.Item2 > 0)
        {
          cur++;
          ans = Math.Max(ans, cur);
        }
        else
        {
          cur--;
        }
      }

      return ans;
    }
  }
}
