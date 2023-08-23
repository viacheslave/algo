namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/find-the-value-of-the-partition/
///    Submission: https://leetcode.com/problems/find-the-value-of-the-partition/submissions/974048468/
/// </summary>
internal class P2740
{
  public class Solution
  {
    public int FindValueOfPartition(int[] nums)
    {
      Array.Sort(nums);

      var ans = int.MaxValue;

      for (int i = 0; i < nums.Length - 1; i++)
      {
        ans = Math.Min(ans, Math.Abs(nums[i] - nums[i + 1]));
      }

      return ans;
    }
  }
}
