namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/apply-operations-to-an-array/
///    Submission: https://leetcode.com/problems/apply-operations-to-an-array/submissions/838202795/
/// </summary>
internal class P2460
{
  public class Solution
  {
    public int[] ApplyOperations(int[] nums)
    {
      for (int i = 0; i < nums.Length - 1; i++)
      {
        if (nums[i] == nums[i + 1])
        {
          nums[i] *= 2;
          nums[i + 1] = 0;
        }
      }

      var ans = new int[nums.Length];

      var index = 0;
      for (int i = 0; i < nums.Length; i++)
      {
        if (nums[i] != 0)
          ans[index++] = nums[i];
      }

      return ans;
    }
  }
}
