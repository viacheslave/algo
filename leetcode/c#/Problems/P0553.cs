namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/optimal-division/
///    Submission: https://leetcode.com/submissions/detail/437093850/
/// </summary>
internal class P0553
{
  public class Solution
  {
    public string OptimalDivision(int[] nums)
    {
      if (nums.Length == 1)
        return nums[0].ToString();

      // maximize interval [0, nums.Length - 1]
      var ans = GetResult(nums, 0, nums.Length - 1, 1);

      return ans.Str;
    }

    public RangeResult GetResult(int[] nums, int start, int end, int mm)
    {
      // no left, no right part
      if (start == end)
        return new RangeResult { Piece = (start, end), Result = nums[start], Str = nums[start].ToString() };

      var ans = new RangeResult
      {
        Result = mm == 1 ? double.MinValue : double.MaxValue
      };

      // recursively select left and right parts
      // try to minimize or maximize the value left/right depending on what's in mm
      // mm = 1 - maximize
      // mm = 0 - minimize
      for (var mid = start; mid < end; mid++)
      {
        var left = GetResult(nums, start, mid, mm);
        var right = GetResult(nums, mid + 1, end, 1 - mm);
        var result = left.Result / right.Result;

        if ((mm == 1 && result > ans.Result) || (mm == 0 && result < ans.Result))
        {
          ans.Left = left;
          ans.Right = right;
          ans.Result = result;
        }
      }

      // left part can be without braces
      var leftStr = ans.Left.Str;

      // right part is always in braces except when it's a single value
      var rightStr = ans.Right.Piece == null ? $"({ans.Right.Str})" : $"{ans.Right.Str}";
      ans.Str = $"{leftStr}/{rightStr}";

      return ans;
    }

    public class RangeResult
    {
      // not null if start == end
      public (int, int)? Piece;

      public RangeResult Left;
      public RangeResult Right;

      public double Result;
      public string Str;
    }
  }
}
