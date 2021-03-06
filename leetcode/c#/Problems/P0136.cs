namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/single-number/
///    Submission: https://leetcode.com/submissions/detail/226732901/
/// </summary>
internal class P0136
{
  public class Solution
  {
    public int SingleNumber(int[] nums)
    {
      HashSet<int> h = new HashSet<int>();

      for (var i = 0; i < nums.Length; i++)
        if (!h.Contains(nums[i]))
          h.Add(nums[i]);
        else
          h.Remove(nums[i]);

      foreach (var item in h)
        return item;

      return 0;
    }
  }
}
