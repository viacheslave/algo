namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/task-scheduler-ii/
///    Submission: https://leetcode.com/submissions/detail/772556543/
/// </summary>
internal class P2365
{
  public class Solution
  {
    public long TaskSchedulerII(int[] tasks, int space)
    {
      var map = new Dictionary<int, long>();

      var ans = 0L;

      // greedy

      for (int i = 0; i < tasks.Length; i++)
      {
        var task = tasks[i];

        if (!map.ContainsKey(task))
        {
          map[task] = ans + space;
          ans++;
          continue;
        }

        var diff = map[task] - ans + 1;

        if (diff > 0)
        {
          // take a break
          // skip a gap
          i--;
          ans += diff;
        }
        else
        {
          // complete the task
          map[task] = ans + space;
          ans++;
        }
      }

      return ans;
    }
  }

}
