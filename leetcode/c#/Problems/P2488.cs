namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-subarrays-with-median-k/
///    Submission: https://leetcode.com/problems/count-subarrays-with-median-k/submissions/850590783/
/// </summary>
internal class P2488
{
  public class Solution
  {
    public int CountSubarrays(int[] nums, int k)
    {
      // convert into - - - + 0 - - +
      var index = -1;

      for (int i = 0; i < nums.Length; i++)
      {
        if (nums[i] == k)
        {
          nums[i] = 0;
          index = i;
          continue;
        }

        nums[i] = (nums[i] < k) ? -1 : 1;
      }

      // calculate sum on the left and on the right side
      var leftMap = new Dictionary<long, int>();
      var rightMap = new Dictionary<long, int>();

      var sum = 0L;

      for (int i = index - 1; i >= 0; i--)
      {
        sum += nums[i];

        if (!leftMap.ContainsKey(sum)) leftMap[sum] = 0;
        leftMap[sum]++;
      }

      sum = 0L;
      for (int i = index + 1; i < nums.Length; i++)
      {
        sum += nums[i];

        if (!rightMap.ContainsKey(sum)) rightMap[sum] = 0;
        rightMap[sum]++;
      }

      var ans = 0;

      foreach (var lkv in leftMap)
      {
        ans += lkv.Value * rightMap.GetValueOrDefault(-lkv.Key, 0);
        ans += lkv.Value * rightMap.GetValueOrDefault(-lkv.Key + 1, 0);
      }

      ans += leftMap.GetValueOrDefault(0, 0);
      ans += leftMap.GetValueOrDefault(1, 0);
      ans += rightMap.GetValueOrDefault(0, 0);
      ans += rightMap.GetValueOrDefault(1, 0);

      return ans + 1;
    }
  }
}
