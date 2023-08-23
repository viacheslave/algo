namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/subarray-with-elements-greater-than-varying-threshold/
///    Submission: https://leetcode.com/submissions/detail/743376769/
/// </summary>
internal class P2334
{
  public class Solution
  {
    public int ValidSubarraySize(int[] nums, int threshold)
    {
      // for every index we find interval where it is the min
      // left and right - keep indices of next min elements to the left and to the right
      // use monotonic stack

      var left = new int[nums.Length];
      var right = new int[nums.Length];

      Array.Fill(left, -1);
      Array.Fill(right, nums.Length);

      var stack = new Stack<(int value, int index)>();

      // left
      for (var i = 0; i < nums.Length; i++)
      {
        while (stack.Count > 0 && stack.Peek().value >= nums[i])
          stack.Pop();

        if (stack.Count == 0)
        {
          stack.Push((nums[i], i));
          continue;
        }

        left[i] = stack.Peek().index;
        stack.Push((nums[i], i));
      }

      // right
      stack.Clear();

      for (var i = nums.Length - 1; i >= 0; i--)
      {
        while (stack.Count > 0 && stack.Peek().value >= nums[i])
          stack.Pop();

        if (stack.Count == 0)
        {
          stack.Push((nums[i], i));
          continue;
        }

        right[i] = stack.Peek().index;
        stack.Push((nums[i], i));
      }

      // check length
      for (int i = 0; i < nums.Length; i++)
      {
        var l = left[i] + 1;
        var r = right[i] - 1;
        var length = r - l + 1;

        var d = threshold / length;

        if (nums[i] > d)
        {
          return length;
        }
      }

      return -1;
    }
  }
}
