using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sort-transformed-array/
  ///    Submission: https://leetcode.com/submissions/detail/451496804/
  ///    Google
  /// </summary>
  internal class P0360
  {
    public class Solution
    {
      public int[] SortTransformedArray(int[] nums, int a, int b, int c)
      {
        var values = nums
          .Select(n => n * n * a + n * b + c)
          .ToList();

        if (a == 0)
        {
          if (b > 0)
          {
            return values.ToArray();
          }
          else
          {
            values.Reverse();
            return values.ToArray();
          }
        }

        if (a > 0)
        {
          var low = -1;
          var min = int.MaxValue;

          for (var i = 0; i < values.Count; i++)
          {
            if (values[i] < min)
            {
              low = i;
              min = values[i];
            }
          }

          if (low == -1)
            return values.ToArray();

          var v1 = new List<int> { values[low] };
          var left = low - 1;
          var right = low + 1;

          while (left >= 0 || right < values.Count)
          {
            if (left < 0)
            {
              v1.Add(values[right]);
              right++;
              continue;
            }

            if (right == values.Count)
            {
              v1.Add(values[left]);
              left--;
              continue;
            }

            if (values[left] < values[right])
            {
              v1.Add(values[left]);
              left--;
            }
            else
            {
              v1.Add(values[right]);
              right++;
            }
          }

          return v1.ToArray();
        }
        else
        {
          var high = -1;
          var max = int.MinValue;

          for (var i = 0; i < values.Count; i++)
          {
            if (values[i] > max)
            {
              high = i;
              max = values[i];
            }
          }

          if (high == -1)
            return values.ToArray();

          var v1 = new List<int> { values[high] };
          var left = high - 1;
          var right = high + 1;

          while (left >= 0 || right < values.Count)
          {
            if (left < 0)
            {
              v1.Add(values[right]);
              right++;
              continue;
            }

            if (right == values.Count)
            {
              v1.Add(values[left]);
              left--;
              continue;
            }

            if (values[left] > values[right])
            {
              v1.Add(values[left]);
              left--;
            }
            else
            {
              v1.Add(values[right]);
              right++;
            }
          }

          v1.Reverse();
          return v1.ToArray();
        }
      }
    }
  }
}
