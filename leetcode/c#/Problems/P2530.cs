namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximal-score-after-applying-k-operations/
///    Submission: https://leetcode.com/problems/maximal-score-after-applying-k-operations/submissions/881957598/
/// </summary>
internal class P2530
{
  public class Solution
  {
    public long MaxKelements(int[] nums, int k)
    {
      var pq = new PriorityQueue<int, int>(nums.Select(n => (n, n)), new ReverseComparer());

      var score = 0L;

      for (int i = 0; i < k; i++)
      {
        var el = pq.Dequeue();
        var value = (int)Math.Ceiling(el / 3d);

        score += el;

        pq.Enqueue(value, value);
      }

      return score;
    }

    private class ReverseComparer : IComparer<int>
    {
      public int Compare(int x, int y) => y - x;
    }
  }
}
