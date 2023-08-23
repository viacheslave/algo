namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimize-maximum-of-array/
///    Submission: https://leetcode.com/problems/minimize-maximum-of-array/submissions/823825899/
/// </summary>
internal class P2439
{
  public class Solution
  {
    public int MinimizeArrayValue(int[] nums)
    {
      var min = nums.Min();
      var max = nums.Max();

      // [3, 7, 1, 6]
      while (true)
      {
        if (max - min <= 1)
        {
          if (Fits(nums, min))
            return min;
          return max;
        }

        var mid = (min + max) >> 1;

        var fits = Fits(nums, mid);
        if (fits)
        {
          max = mid;
        }
        else
        {
          min = mid;
        }
      }
    }

    private static bool Fits(int[] nums, int top)
    {
      var arr = new long[nums.Length];
      Array.Copy(nums, arr, nums.Length);

      for (int i = arr.Length - 1; i > 0; i--)
      {
        var diff = arr[i] - top;
        if (diff > 0)
        {
          arr[i] -= diff;
          arr[i - 1] += diff;
        }
      }

      var over = arr.Any(item => item > top);
      return !over;
    }
  }

}
