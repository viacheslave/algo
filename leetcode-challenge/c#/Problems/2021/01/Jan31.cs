using System;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/583/week-5-january-29th-january-31st/3623/
  ///    https://leetcode.com/submissions/detail/450060067/?from=explore&item_id=3623
  /// </summary>
  internal class Jan31
  {
    public class Solution
    {
      public void NextPermutation(int[] nums)
      {
        if (nums.Length < 2)
          return;

        var baseIndex = nums.Length - 2;

        while (baseIndex >= 0)
        {
          for (var i = nums.Length - 1; i > baseIndex; i--)
          {
            if (nums[baseIndex] < nums[i])
            {
              var tmp = nums[baseIndex];
              nums[baseIndex] = nums[i];
              nums[i] = tmp;

              if (baseIndex + 1 < nums.Length - 1)
              {
                Sort(nums, baseIndex + 1);
              }

              return;
            }
          }

          baseIndex--;
        }

        Array.Reverse(nums);
      }

      private void Swap(int[] nums, int left, int right)
      {
        var tmp = nums[left];
        nums[left] = nums[right];
        nums[right] = tmp;
      }

      private void Sort(int[] nums, int start)
      {
        var b = start + 1;

        while (b < nums.Length)
        {
          var current = b;
          while (current > start)
          {
            if (nums[current] < nums[current - 1])
            {
              Swap(nums, current, current - 1);
              current--;
              continue;
            }
            break;
          }

          b++;
        }
      }
    }
  }
}

