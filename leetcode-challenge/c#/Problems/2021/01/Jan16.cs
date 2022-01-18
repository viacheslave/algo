using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3606/
  ///    https://leetcode.com/submissions/detail/444082299/?from=explore&item_id=3606
  /// </summary>
  internal class Jan16
  {
    public class Solution
    {
      public int FindKthLargest(int[] nums, int k)
      {
        if (nums.Length == 0)
          return 0;

        if (nums.Length == 1)
          return nums[0];

        var maxArray = new List<int>();

        for (var i = 0; i < nums.Length; i++)
        {
          maxArray.Add(nums[i]);

          Shift(maxArray);
        }

        return GetKthMax(maxArray, k);
      }

      private void Shift(List<int> arr)
      {
        if (arr.Count == 1)
          return;

        int index = arr.Count - 1;
        while (index > 0)
        {
          if (arr[index] > arr[index - 1])
          {
            var tmp = arr[index];
            arr[index] = arr[index - 1];
            arr[index - 1] = tmp;

            index--;
            continue;
          }
          break;
        }
      }

      private int GetKthMax(List<int> arr, int k)
      {
        return arr[k - 1];
      }
    }
  }
}

