namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-closest-number-to-zero/
///    Submission: https://leetcode.com/submissions/detail/689652708/
/// </summary>
internal class P2239
{
  public class Solution
  {
    public int FindClosestNumber(int[] nums)
    {
      Array.Sort(nums);

      var dist = int.MaxValue;
      var ans = int.MaxValue;

      foreach (var nu in nums)
      {
        if (dist >= Math.Abs(nu))
        {
          dist = Math.Abs(nu);
          ans = nu;
        }
      }

      return ans;
    }
  }
}
