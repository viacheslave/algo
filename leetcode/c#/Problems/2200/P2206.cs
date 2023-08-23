namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/divide-array-into-equal-pairs/
///    Submission: https://leetcode.com/submissions/detail/689845498/
/// </summary>
internal class P2206
{
  public class Solution
  {
    public bool DivideArray(int[] nums)
    {
      Array.Sort(nums);

      for (int i = 0; i < nums.Length; i += 2)
      {
        if (nums[i + 1] != nums[i])
          return false;
      }

      return true;
    }
  }

}
