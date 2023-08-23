namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-excellent-pairs/
///    Submission: https://leetcode.com/submissions/detail/756570169/
/// </summary>
internal class P2354
{
  public class Solution
  {
    public long CountExcellentPairs(int[] nums, int k)
    {
      var numCount = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
      var keys = numCount.Keys;

      var numBits = keys.Select(x => (num: x, bits: GetNumBits(x)))
        .GroupBy(x => x.bits)
        .ToDictionary(x => x.Key, x => x.Count());

      var psum = new int[32];
      psum[^1] = numBits.ContainsKey(31) ? numBits[31] : 0;

      for (var i = 30; i >= 0; i--)
      {
        psum[i] = psum[i + 1];
        if (numBits.ContainsKey(i))
        {
          psum[i] = numBits[i] + psum[i + 1];
        }
      }

      // (a || b) + (a & b) is simply the sum of bits of a and the bits of b 

      var ans = 0L;

      for (var i = 0; i < 32; i++)
      {
        if (!numBits.ContainsKey(i))
          continue;

        var minAllowed = k - i;
        if (minAllowed < 0) minAllowed = 0;
        if (minAllowed > 31) minAllowed = 31;

        ans += 1L * numBits[i] * psum[minAllowed];
      }

      return ans;
    }

    private int GetNumBits(int x)
    {
      var ans = 0;

      while (x > 0)
      {
        if (x % 2 == 1)
        {
          ans++;
        }
        x >>= 1;
      }

      return ans;
    }
  }
}
