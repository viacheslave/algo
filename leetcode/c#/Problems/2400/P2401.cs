namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-nice-subarray/
///    Submission: https://leetcode.com/submissions/detail/793899661/
/// </summary>
internal class P2401
{
  public class Solution
  {
    public int LongestNiceSubarray(int[] nums)
    {
      // sliding window
      // the length cannot be greater than 30

      int l = 0, r = 0;
      int ans = 0;

      int[] digits = new int[30];

      while (r < nums.Length)
      {
        if (!AllOnes(digits))
        {
          while (!AllOnes(digits))
          {
            ModifyDigits(nums[l], digits, (d, i) => d[i]--);
            l++;
          }

          r++;
          continue;
        }

        ModifyDigits(nums[r], digits, (d, i) => d[i]++);

        if (AllOnes(digits))
        {
          ans = Math.Max(ans, r - l + 1);
          r++;
        }
      }

      return ans;
    }

    private bool AllOnes(int[] digits) => digits.All(d => d <= 1);

    private void ModifyDigits(int v, int[] digits, Action<int[], int> action)
    {
      var index = 0;
      while (v > 0)
      {
        if (v % 2 == 1)
          action(digits, index);
        v >>= 1;
        index++;
      }
    }
  }
}
