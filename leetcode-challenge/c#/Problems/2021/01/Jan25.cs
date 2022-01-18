using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/582/week-4-january-22nd-january-28th/3616/
  ///    https://leetcode.com/submissions/detail/448953928/?from=explore&item_id=3616
  /// </summary>
  internal class Jan25
  {
    public class Solution
    {
      public bool KLengthApart(int[] nums, int k)
      {
        var ones = nums
          .Select((n, i) => (i, n))
          .Where(n => n.n == 1)
          .Select(n => n.i)
          .ToList();

        if (ones.Count <= 1)
          return true;

        var dist = new int[ones.Count - 1];

        for (int i = 0; i < ones.Count - 1; i++)
          dist[i] = ones[i + 1] - ones[i] - 1;

        return dist.All(n => n >= k);
      }
    }
  }
}

