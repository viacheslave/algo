namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-all-good-indices/
///    Submission: https://leetcode.com/submissions/detail/808162719/
/// </summary>
internal class P2420
{
  public class Solution
  {
    public IList<int> GoodIndices(int[] nums, int k)
    {
      // greedy
      // ltr, rtl

      var left = new int[nums.Length];
      var right = new int[nums.Length];

      left[0] = 0;
      right[nums.Length - 1] = nums.Length - 1;

      for (var i = 1; i < nums.Length; i++)
      {
        left[i] = nums[i] <= nums[i - 1] ? left[i - 1] : i;
      }

      for (var i = nums.Length - 1 - 1; i >= 0; i--)
      {
        right[i] = nums[i] <= nums[i + 1] ? right[i + 1] : i;
      }

      var ans = new List<int>();

      for (var i = k; i < nums.Length - k; i++)
      {
        var l = (i - 1) - left[i - 1];
        var r = right[i + 1] - (i + 1);

        if (l + 1 >= k && r + 1 >= k)
        {
          ans.Add(i);
        }
      }

      return ans;
    }
  }
}
