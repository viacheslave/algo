namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/longest-non-decreasing-subarray-from-two-arrays/
///    Submission: https://leetcode.com/problems/longest-non-decreasing-subarray-from-two-arrays/submissions/1026800462/
/// </summary>
internal class P2771
{
  public class Solution
  {
    public int MaxNonDecreasingLength(int[] nums1, int[] nums2)
    {
      var n = nums1.Length;
      var dp = new Dictionary<int, Dictionary<int, int>>();

      dp.TryAdd(0, new Dictionary<int, int>());

      for (int i = 0; i < n; i++)
      {
        dp[i] = new Dictionary<int, int>();
        dp[i][nums1[i]] = 1;
        dp[i][nums2[i]] = 1;
      }

      for (int i = 1; i < n; i++)
      {
        foreach (var item in dp[i - 1])
        {
          if (nums1[i] >= item.Key)
            dp[i][nums1[i]] = Math.Max(dp[i].GetValueOrDefault(nums1[i], 1), item.Value + 1);

          if (nums2[i] >= item.Key)
            dp[i][nums2[i]] = Math.Max(dp[i].GetValueOrDefault(nums2[i], 1), item.Value + 1);
        }
      }

      return dp.SelectMany(x => x.Value).Max(x => x.Value);
    }
  }
}
