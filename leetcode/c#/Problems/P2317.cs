namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-xor-after-operations/
///    Submission: https://leetcode.com/submissions/detail/731099739/
/// </summary>
internal class P2317
{
  public class Solution
  {
    public int MaximumXOR(int[] nums)
    {
      // nums[i] & (nums[i] ^ x) unsets arbitrary bit
      // to maximize result we should make sure that the count of 1's in ith bit is odd
      // so, if it's already odd - do nothing
      // otherwise, we can make it odd unless the count is greater than zero

      var ans = 0;

      var bucket = new int[31];

      foreach (var num in nums)
      {
        var n = num;
        for (var i = 0; i < 31; i++)
        {
          if (n % 2 == 1)
          {
            bucket[i]++;
          }

          n >>= 1;
        }
      }

      // chekc for zero count
      for (var i = 0; i < bucket.Length; i++)
      {
        if (bucket[i] == 0)
          continue;

        ans += 1 << i;
      }

      return ans;
    }
  }
}
