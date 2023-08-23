namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-subarray-min-product/
///    Submission: https://leetcode.com/submissions/detail/714066188/
/// </summary>
internal class P1856
{
  public class Solution
  {
    public int MaxSumMinProduct(int[] nums)
    {
      // prefix sums
      var prefixSums = new long[nums.Length + 1];

      for (var i = 0; i < nums.Length; i++)
      {
        prefixSums[i + 1] = prefixSums[i] + nums[i];
      }

      // monotonous stacks (left + right)
      // leftIndex and rightIndex indicate the max boundaries (greedy) of the subarray where the ith element is minimum

      var stack = new Stack<(int value, int index)>();

      var leftIndex = new int[nums.Length];
      var rightIndex = new int[nums.Length];

      for (var i = 0; i < nums.Length; i++)
      {
        while (stack.Count > 0 && stack.Peek().value >= nums[i])
          stack.Pop();

        leftIndex[i] = stack.Count == 0 ? 0 : stack.Peek().index + 1;
        stack.Push((nums[i], i));
      }

      stack.Clear();

      for (var i = nums.Length - 1; i >= 0; i--)
      {
        while (stack.Count > 0 && stack.Peek().value >= nums[i])
          stack.Pop();

        rightIndex[i] = stack.Count == 0 ? nums.Length - 1 : stack.Peek().index - 1;
        stack.Push((nums[i], i));
      }

      var max = 0L;

      for (var i = 0; i < nums.Length; i++)
      {
        var l = leftIndex[i];
        var r = rightIndex[i];
        var sum = prefixSums[r + 1] - prefixSums[l];
        max = Math.Max(max, sum * nums[i]);
      }

      return (int)(max % ((int)1e9 + 7));
    }
  }

}
