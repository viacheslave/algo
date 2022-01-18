using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/615/week-3-august-15th-august-21st/3892/
  /// 
  /// </summary>
  internal class Aug16
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

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * int param_1 = obj.SumRange(i,j);
     */
  }
}
