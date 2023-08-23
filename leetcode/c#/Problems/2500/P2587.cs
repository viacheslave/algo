namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/rearrange-array-to-maximize-prefix-score/
///    Submission: https://leetcode.com/problems/rearrange-array-to-maximize-prefix-score/submissions/918285454/
/// </summary>
internal class P2587
{
  public class Solution
  {
    public int MaxScore(int[] nums)
    {
      // descreasing
      nums = nums
        .OrderByDescending(_ => _)
        .ToArray();

      var prefixSums = new long[nums.Length + 1];
      for (int i = 0; i < nums.Length; i++)
      {
        prefixSums[i + 1] = prefixSums[i] + nums[i];
      }

      return prefixSums.Count(_ => _ > 0);
    }
  }
}
