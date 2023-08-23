namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-elements-with-strictly-smaller-and-greater-elements/
///    Submission: https://leetcode.com/submissions/detail/625918149/
/// </summary>
internal class P2148
{
  public class Solution
  {
    public int CountElements(int[] nums)
    {
      var min = nums.Min();
      var max = nums.Max();

      return nums.Count(x => x > min && x < max);
    }
  }
}
