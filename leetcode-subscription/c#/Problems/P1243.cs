using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/array-transformation/
  ///    Submission: https://leetcode.com/submissions/detail/451142075/
  ///    Virtu Financial
  /// </summary>
  internal class P1243
  {
    public class Solution
    {
      public IList<int> TransformArray(int[] arr)
      {
        while (true)
        {
          var changes = new int[arr.Length];

          for (var i = 1; i < arr.Length - 1; i++)
          {
            if (arr[i - 1] < arr[i] && arr[i] > arr[i + 1])
              changes[i] = -1;

            if (arr[i - 1] > arr[i] && arr[i] < arr[i + 1])
              changes[i] = 1;
          }

          if (changes.All(c => c == 0))
            break;

          for (var i = 1; i < arr.Length - 1; i++)
            arr[i] += changes[i];
        }

        return arr.ToList();
      }
    }
  }
}
