namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-pairs-in-array/
///    Submission: https://leetcode.com/submissions/detail/750538355/
/// </summary>
internal class P2341
{
  public class Solution
  {
    public int[] NumberOfPairs(int[] nums)
    {
      var arr = nums.GroupBy(x => x)
        .Select(x => (remove: x.Count() / 2, left: x.Count() % 2))
        .ToArray();

      var ans = new int[2];

      foreach (var item in arr)
      {
        ans[0] += item.remove;
        ans[1] += item.left;
      }

      return ans;
    }
  }
}
