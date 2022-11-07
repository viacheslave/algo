namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k/
///    Submission: https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k/submissions/838201104/
/// </summary>
internal class P2461
{
  public class Solution
  {
    public long MaximumSubarraySum(int[] nums, int k)
    {
      var index = k - 1;
      var map = nums.Take(k).GroupBy(h => h)
        .ToDictionary(f => f.Key, f => f.Count());

      var runningSum = nums.Take(k).Sum(f => 1L * f);
      var ans = map.Count == k ? runningSum : 0L;

      // sliding window

      for (int i = 0; i < nums.Length; i++)
      {
        if (index == nums.Length - 1)
          break;

        index++;

        if (!map.ContainsKey(nums[index]))
          map[nums[index]] = 0;
        map[nums[index]]++;

        if (map.ContainsKey(nums[index - k]))
        {
          map[nums[index - k]]--;
          if (map[nums[index - k]] == 0)
            map.Remove(nums[index - k]);
        }

        runningSum += nums[index];
        runningSum -= nums[index - k];

        if (map.Count == k)
        {
          ans = Math.Max(ans, runningSum);
        }
      }

      return ans;
    }
  }

}
