using System;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/580/week-2-january-8th-january-14th/3603/
  ///    https://leetcode.com/submissions/detail/442824329/?from=explore&item_id=3603
  /// </summary>
  internal class Jan14
  {
    public class Solution
    {
      public int MinOperations(int[] nums, int x)
      {
        //[3,2,20,1,1,3]

        var targetSum = nums.Sum() - x;

        if (targetSum < 0)
          return -1;

        if (targetSum == 0)
          return nums.Length;

        var prefix = new int[nums.Length + 1];
        for (var i = 0; i < nums.Length; i++)
          prefix[i + 1] = prefix[i] + nums[i];

        var ans = int.MinValue;

        for (var i = 0; i < nums.Length; i++)
        {
          if (GetSum(prefix, i, i) > targetSum)
            continue;

          // binary search
          var left = i;
          var right = nums.Length - 1;

          while (true)
          {
            var sumLeft = GetSum(prefix, left, i);
            var sumRight = GetSum(prefix, right, i);

            if (right - left <= 1)
            {
              if (sumRight == targetSum)
                ans = Math.Max(ans, right - i + 1);

              if (sumLeft == targetSum)
                ans = Math.Max(ans, left - i + 1);

              break;
            }

            var mid = (left + right) / 2;
            var sumMid = GetSum(prefix, mid, i);

            if (sumMid > targetSum)
              right = mid;
            else
              left = mid;
          }
        }

        if (ans == int.MinValue)
          return -1;

        return nums.Length - ans;
      }

      private int GetSum(int[] prefix, int right, int left)
      {
        return prefix[right + 1] - prefix[left];
      }
    }
  }
}

