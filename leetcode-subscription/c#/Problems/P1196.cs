using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/how-many-apples-can-you-put-into-the-basket/
  ///    Submission: https://leetcode.com/submissions/detail/451416088/
  ///    Virtu Financial
  /// </summary>
  internal class P1196
  {
    public class Solution
    {
      public int MaxNumberOfApples(int[] arr)
      {
        Array.Sort(arr);

        var weight = 0;

        for (var i = 0; i < arr.Length; i++)
        {
          if (weight + arr[i] <= 5000)
            weight += arr[i];

          else return i;
        }

        return arr.Length;
      }
    }
  }
}
