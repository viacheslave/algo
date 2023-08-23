namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-difference-in-sums-after-removal-of-elements/
///    Submission: https://leetcode.com/submissions/detail/635187338/
/// </summary>
internal class P2163
{
  public class Solution
  {
    public long MinimumDifference(int[] nums)
    {
      var n = nums.Length / 3;
      var leftSum = nums.Take(n).Select(x => (long)x).Sum();
      var rightSum = nums.Skip(2 * n).Take(n).Select(x => (long)x).Sum();

      var minLeftSum = new List<long> { leftSum };
      var maxRightSum = new List<long> { rightSum };

      var pq = new PriorityQueue<long, long>(Comparer<long>.Create((a, b) => (int)(b - a)));
      pq.EnqueueRange(nums.Take(n).Select(a => ((long)a, (long)a)));

      var current = leftSum;
      for (var i = n; i < 2 * n; i++)
      {
        pq.Enqueue(nums[i], nums[i]);
        var item = pq.Dequeue();

        current = current + nums[i] - item;
        minLeftSum.Add(current);
      }

      pq = new PriorityQueue<long, long>();
      pq.EnqueueRange(nums.Skip(2 * n).Take(n).Select(a => ((long)a, (long)a)));

      current = rightSum;
      for (var i = 2 * n - 1; i >= n; i--)
      {
        pq.Enqueue(nums[i], nums[i]);
        var item = pq.Dequeue();

        current = current + nums[i] - item;
        maxRightSum.Add(current);
      }

      var ans = long.MaxValue;

      for (var i = 0; i < minLeftSum.Count; i++)
      {
        ans = Math.Min(ans, minLeftSum[i] - maxRightSum[maxRightSum.Count - 1 - i]);
      }

      return ans;
    }
  }

}
