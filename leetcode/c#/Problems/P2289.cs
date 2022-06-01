namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/steps-to-make-array-non-decreasing/
///    Submission: https://leetcode.com/submissions/detail/711463678/
/// </summary>
internal class P2289
{
  public class Solution
  {
    public int TotalSteps(int[] nums)
    {
      var stack = new Stack<(int value, int index)>();

      var dp = new int[nums.Length];

      for (var i = nums.Length - 1; i >= 0; i--)
      {
        while (stack.Count > 0 && stack.Peek().value < nums[i])
        {
          var item = stack.Pop();
          dp[i] = Math.Max(dp[i] + 1, dp[item.index]);
        }

        stack.Push((nums[i], i));
      }

      return dp.Max();
    }
  }
}
