namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/contains-duplicate/
///    Submission: https://leetcode.com/submissions/detail/228687815/
/// </summary>
internal class P0217
{
  public class Solution
  {
    public bool ContainsDuplicate(int[] nums)
    {
      if (nums.Length < 2)
        return false;

      HashSet<int> values = new HashSet<int>();

      for (var i = 0; i < nums.Length; i++)
      {
        if (values.Contains(nums[i]))
          return true;

        values.Add(nums[i]);
      }

      return false;
    }
  }
}
