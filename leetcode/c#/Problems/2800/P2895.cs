namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-processing-time/
///    Submission: https://leetcode.com/problems/minimum-processing-time/submissions/1074979023/
/// </summary>
internal class P2895
{
  public class Solution 
  {
    public int MinProcessingTime(IList<int> processorTime, IList<int> tasks) 
    {
      var ans = int.MinValue;
      var sortedProcessors = processorTime.OrderBy(r => r).ToList();
      var sortedTasks = tasks.OrderByDescending(t => t).ToList();
      
      var iteration = 0;
      foreach (var proc in sortedProcessors)
      {
        var times = new [] 
        {
          proc + sortedTasks[iteration * 4 + 0],
          proc + sortedTasks[iteration * 4 + 1],
          proc + sortedTasks[iteration * 4 + 2],
          proc + sortedTasks[iteration * 4 + 3],
        };

        ans = Math.Max(ans, times.Max());

        iteration++;
      }
      
      return ans;
    }
  }
}
