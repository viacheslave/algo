namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/time-needed-to-buy-tickets/
///    Submission: https://leetcode.com/submissions/detail/587079919/
/// </summary>
internal class P2073
{
  public class Solution
  {
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
      var queue = new Queue<(int, int)>();
      for (int i = 0; i < tickets.Length; i++)
        queue.Enqueue((i, tickets[i]));

      var ans = 1;

      while (queue.Count > 0)
      {
        var item = queue.Dequeue();
        if (item.Item1 == k && item.Item2 == 1)
          break;

        ans++;

        if (item.Item2 > 1)
          queue.Enqueue((item.Item1, item.Item2 - 1));
      }

      return ans;
    }
  }
}
