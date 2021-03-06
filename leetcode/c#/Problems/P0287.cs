namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-duplicate-number/
///    Submission: https://leetcode.com/submissions/detail/407761600/
/// </summary>
internal class P0287
{
  public class Solution
  {
    public int FindDuplicate(int[] nums)
    {
      Array.Sort(nums);

      var sum = 0;
      for (var i = 0; i < nums.Length - 1; i++)
        if (nums[i] == nums[i + 1])
          return nums[i];

      return -1;
    }
  }
}
