using System.Numerics;

namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-ways-to-reach-a-position-after-exactly-k-steps/
///    Submission: https://leetcode.com/submissions/detail/793899661/
/// </summary>
internal class P2400
{
  public class Solution
  {
    public int NumberOfWays(int startPos, int endPos, int k)
    {
      var mod = (int)(1e9 + 7);
      var dist = Math.Abs(endPos - startPos);
      var left = k - dist;

      if (left < 0)
        return 0;

      if (left % 2 == 1)
        return 0;

      if (left == 0)
        return 1;

      // 1 2 3 4 5 6 7
      var nums = Enumerable.Range(1, k).ToArray();

      left /= 2;

      var head = new BigInteger(1);
      var tail = new BigInteger(1);

      for (var i = k - left; i < k; i++)
        tail *= nums[i];

      for (var i = 0; i < left; i++)
        head *= nums[i];

      var ans = BigInteger.Divide(tail, head);
      return (int)BigInteger.ModPow(ans, BigInteger.One, new BigInteger(mod));
    }
  }
}
