namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-square-streak-in-an-array/
///    Submission: https://leetcode.com/problems/longest-square-streak-in-an-array/submissions/862141470/
/// </summary>
internal class P2501
{
  public class Solution
  {
    public int LongestSquareStreak(int[] nums)
    {
      // brute force
      var dist = nums.Select(f => 1L * f).Distinct().OrderByDescending(f => f);
      var map = new Dictionary<long, int>();
      var ans = 0;

      foreach (var num in dist)
      {
        var count = 1;

        if (map.ContainsKey(1L * num * num))
          count += map[1L * num * num];

        map[num] = count;
        ans = Math.Max(ans, count);
      }

      return ans == 1 ? -1 : ans;
    }
  }
}
