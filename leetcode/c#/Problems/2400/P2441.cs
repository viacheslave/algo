namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/largest-positive-integer-that-exists-with-its-negative/
///    Submission: https://leetcode.com/problems/largest-positive-integer-that-exists-with-its-negative/submissions/823859270/
/// </summary>
internal class P2441
{
  public class Solution
  {
    public int FindMaxK(int[] nums)
    {
      var set = nums.ToHashSet();

      var max = -1;

      foreach (var item in set)
      {
        if (set.Contains(-item))
        {
          max = Math.Max(max, item);
        }
      }

      return max;
    }
  }
}
