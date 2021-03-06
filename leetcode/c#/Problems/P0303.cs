namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/range-sum-query-immutable/
///    Submission: https://leetcode.com/submissions/detail/230649680/
/// </summary>
internal class P0303
{
  public class Solution
  {
    public class NumArray
    {

      int[] arr;

      public NumArray(int[] nums)
      {
        arr = nums;
      }

      public int SumRange(int i, int j)
      {
        if (i < 0 || i >= arr.Length)
          return 0;

        if (j < 0 || j >= arr.Length)
          return 0;

        var sum = 0;

        for (var index = i; index <= j; index++)
          sum += arr[index];

        return sum;
      }
    }

  }
}
