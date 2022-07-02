namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-score-of-spliced-array/
///    Submission: https://leetcode.com/submissions/detail/736598251/
/// </summary>
internal class P2321
{
  public class Solution
  {
    public int MaximumsSplicedArray(int[] nums1, int[] nums2)
    {
      // Idea:
      // get the diff arr and find the max sum of all sub-arrays
      // try to subtract or add it 
      // and get max resulting sum

      return Math.Max(
        GetMax(nums1, nums2),
        GetMax(nums2, nums1)
      );
    }

    private int GetMax(int[] minArr, int[] maxArr)
    {
      var diff = Enumerable.Range(0, minArr.Length).Select(i => minArr[i] - maxArr[i]).ToArray();

      // Max sub-array sum
      // Kadane

      var dp = new int[diff.Length];
      var max = diff[0];

      dp[0] = diff[0];

      for (var i = 1; i < diff.Length; i++)
      {
        dp[i] = Math.Max(dp[i - 1] + diff[i], diff[i]);
        max = Math.Max(max, dp[i]);
      }

      if (max <= 0)
      {
        return Math.Max(minArr.Sum(), maxArr.Sum());
      }

      return maxArr.Sum() + max;
    }
  }
}
