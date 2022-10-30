namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-subarrays-with-gcd-equal-to-k/
///    Submission: https://leetcode.com/problems/number-of-subarrays-with-gcd-equal-to-k/submissions/830116131/
/// </summary>
internal class P2447
{
  public class Solution
  {
    public int SubarrayGCD(int[] nums, int k)
    {
      var ans = 0;

      for (int i = 0; i < nums.Length; i++)
      {
        var gcd = 0;

        for (int j = i; j < nums.Length; j++)
        {
          if (j == i)
          {
            gcd = nums[j];
          }
          else
          {
            gcd = GetGcd(gcd, nums[j]);
          }

          if (gcd == k)
            ans++;

          if (gcd < k)
            break;
        }
      }

      return ans;
    }

    private int GetGcd(int a, int b)
    {
      if (a == b)
        return a;

      return a > b
        ? GetGcd(a - b, b)
        : GetGcd(a, b - a);
    }
  }
}
