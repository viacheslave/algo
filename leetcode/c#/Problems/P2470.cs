namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-subarrays-with-lcm-equal-to-k/
///    Submission: https://leetcode.com/problems/number-of-subarrays-with-lcm-equal-to-k/submissions/842888330/
/// </summary>
internal class P2470
{
  public class Solution
  {
    public int SubarrayLCM(int[] nums, int k)
    {
      var ans = 0;

      for (int i = 0; i < nums.Length; i++)
      {
        var lcm = nums[i];

        for (int j = i; j < nums.Length; j++)
        {
          var gcd = GetGcd(lcm, nums[j]);
          lcm = (lcm * nums[j]) / gcd;

          if (lcm > k)
            break;

          if (lcm == k)
            ans++;
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
