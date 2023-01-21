namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/difference-between-element-sum-and-digit-sum-of-an-array/
///    Submission: https://leetcode.com/problems/difference-between-element-sum-and-digit-sum-of-an-array/submissions/880626290/
/// </summary>
internal class P2535
{
  public class Solution
  {
    public int DifferenceOfSum(int[] nums)
    {
      return Math.Abs(
          nums.Sum() -
          nums.Select(n => n.ToString().Sum(ch => int.Parse(ch.ToString()))).Sum());
    }
  }
}
