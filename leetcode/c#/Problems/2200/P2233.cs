namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-product-after-k-increments/
///    Submission: https://leetcode.com/submissions/detail/677555572/
/// </summary>
internal class P2233
{
  public class Solution
  {
    public int MaximumProduct(int[] nums, int k)
    {
      var pq = new PriorityQueue<int, int>(nums.Select(a => (a, a)));

      for (int i = 0; i < k; i++)
      {
        var a = pq.Dequeue();
        pq.Enqueue(a + 1, a + 1);
      }

      var ans = 1L;

      foreach (var a in pq.UnorderedItems)
      {
        ans *= a.Element;
        ans %= (int)(1e9 + 7);
      }

      return (int)ans;
    }
  }
}
