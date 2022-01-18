namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-width-ramp/
///    Submission: https://leetcode.com/submissions/detail/585076982/
/// </summary>
internal class P0962
{
  public class Solution
  {
    public int MaxWidthRamp(int[] nums)
    {
      var stack = new Stack<(int value, int index)>();
      var ans = 0;

      for (var i = 0; i < nums.Length; i++)
      {
        var value = nums[i];
        var index = -1;

        if (stack.Count == 0 || stack.Peek().value > value)
        {
          var start = stack.Count == 0 ? 0 : stack.Peek().index + 1;

          for (var j = start; j < i; j++)
          {
            if (nums[j] <= value)
            {
              index = j;
              break;
            }

            if (stack.Count == 0 || nums[j] <= stack.Peek().value)
              stack.Push((nums[j], j));
          }
        }
        else
        {
          while (stack.Count > 0 && stack.Peek().value <= value)
            index = stack.Pop().index;
        }

        if (index != -1)
          ans = Math.Max(ans, i - index);

      }
      return ans;
    }
  }
}
