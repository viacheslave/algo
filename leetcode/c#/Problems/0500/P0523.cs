namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/continuous-subarray-sum/
///    Submission: https://leetcode.com/submissions/detail/238337742/
/// </summary>
internal class P0523
{
  public class Solution
  {
    public bool CheckSubarraySum(int[] nums, int k)
    {
      if (nums.Length == 0)
        return false;

      for (var i = 0; i < nums.Length - 1; i++)
      {
        if (Get(nums, i, k))
          return true;
      }

      return false;
    }

    private bool Get(int[] nums, int i, int k)
    {
      var sum = nums[i];

      for (var index = i + 1; index < nums.Length; index++)
      {
        sum += nums[index];
        if ((k == 0 && sum == k) || (k != 0 && sum % k == 0))
          return true;
      }

      return false;
    }
  }
}

/// <summary>
///    Problem: https://leetcode.com/problems/continuous-subarray-sum/
///    Submission: https://leetcode.com/problems/continuous-subarray-sum/submissions/830866738/
/// </summary>
internal class P0523_2
{
  public class Solution
  {
    public bool CheckSubarraySum(int[] nums, int k)
    {
      if (nums.Length == 0)
        return false;

      var prefixSums = new int[nums.Length + 1];

      // calculate prefix sums
      // and mod them k

      for (int i = 0; i < nums.Length; i++)
      {
        prefixSums[i + 1] = prefixSums[i] + nums[i];
      }

      for (int i = 0; i < prefixSums.Length; i++)
      {
        prefixSums[i] %= k;
      }

      var intervals = prefixSums
        .Select((p, i) => (p, i))
        .GroupBy(p => p.p).ToDictionary(p => p.Key, p => p.Select(r => r.i).ToArray());

      // then check the collection of each mod
      foreach (var interval in intervals)
      {
        if (interval.Value.Length > 1 && interval.Value[^1] - interval.Value[0] > 1)
          return true;
      }

      return false;
    }
  }
}
