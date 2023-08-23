namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/rearrange-array-elements-by-sign/
///    Submission: https://leetcode.com/submissions/detail/625917223/
/// </summary>
internal class P2149
{
  public class Solution
  {
    public int[] RearrangeArray(int[] nums)
    {
      return
        nums.Where(x => x > 0)
          .Zip(nums.Where(x => x < 0))
          .Select(p => new int[] { p.First, p.Second })
          .SelectMany(x => x)
          .ToArray();
    }
  }

}
