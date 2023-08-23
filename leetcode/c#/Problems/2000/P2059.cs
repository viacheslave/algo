namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-operations-to-convert-number/
///    Submission: https://leetcode.com/submissions/detail/582392849/
/// </summary>
internal class P2059
{
  public class Solution
  {
    public int MinimumOperations(int[] nums, int start, int goal)
    {
      // BFS
      var visited = new HashSet<int>();

      var queue = new Queue<(int value, int steps)>();
      queue.Enqueue((start, 0));
      visited.Add(start);

      while (queue.Count > 0)
      {
        var item = queue.Dequeue();
        if (item.value == goal)
          return item.steps;

        if (item.value < 0 || item.value > 1000)
          continue;

        foreach (var n in nums)
        {
          var v1 = item.value + n;
          var v2 = item.value - n;
          var v3 = item.value ^ n;

          if (!visited.Contains(v1))
          {
            queue.Enqueue((v1, item.steps + 1));
            visited.Add(v1);
          }

          if (!visited.Contains(v2))
          {
            queue.Enqueue((v2, item.steps + 1));
            visited.Add(v2);
          }

          if (!visited.Contains(v3))
          {
            queue.Enqueue((v3, item.steps + 1));
            visited.Add(v3);
          }
        }
      }

      return -1;
    }
  }
}
