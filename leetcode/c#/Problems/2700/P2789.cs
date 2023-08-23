namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/largest-element-in-an-array-after-merge-operations/
///    Submission: https://leetcode.com/problems/largest-element-in-an-array-after-merge-operations/submissions/1019161916/
/// </summary>
internal class P2789
{
  public class Solution
  {
    public long MaxArrayValue(int[] nums)
    {
      long ans = nums[^1];

      for (int i = nums.Length - 2; i >= 0; i--)
      {
        if (nums[i] > ans)
        {
          ans = nums[i];
          continue;
        }

        ans += nums[i];
      }

      return ans;
    }
  }
}
