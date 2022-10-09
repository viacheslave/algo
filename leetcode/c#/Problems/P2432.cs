using System.Numerics;

namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/the-employee-that-worked-on-the-longest-task/
///    Submission: https://leetcode.com/problems/the-employee-that-worked-on-the-longest-task/submissions/818603958/
/// </summary>
internal class P2432
{
  public class Solution
  {
    public int HardestWorker(int n, int[][] logs)
    {
      var times = new (int id, int start, int end)[logs.Length];
      times[0] = (id: logs[0][0], start: 0, end: logs[0][1]);

      for (int i = 1; i < logs.Length; i++)
      {
        times[i] = (id: logs[i][0], start: logs[i - 1][1], end: logs[i][1]);
      }

      var max = times.Max(t => t.end - t.start);

      return times
        .Where(d => d.end - d.start == max)
        .MinBy(d => d.id)
        .id;
    }
  }
}
