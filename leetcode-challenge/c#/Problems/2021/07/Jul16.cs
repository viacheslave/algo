using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/610/week-3-july-15th-july-21st/3816/
  /// 
  /// </summary>
  internal class Jul16
  {
    public class Solution
    {
      public IList<IList<int>> FourSum(int[] nums, int target)
      {
        Array.Sort(nums);

        var res = new List<IList<int>>();

        for (var i = 0; i < nums.Length - 3; i++)
        {
          for (var l = nums.Length - 1; l > i + 2; l--)
          {
            var j = i + 1;
            var k = l - 1;

            while (j < k)
            {
              if (nums[i] + nums[j] + nums[k] + nums[l] < target)
              {
                j++; continue;
              }

              if (nums[i] + nums[j] + nums[k] + nums[l] > target)
              {
                k--; continue;
              }

              res.Add(new List<int>() { nums[i], nums[j], nums[k], nums[l] });

              while (k - 1 >= 0 && nums[k - 1] == nums[k])
                k--;

              while (j + 1 < nums.Length && nums[j + 1] == nums[j])
                j++;

              k--;
              j++;
            }

            while (l - 1 > i + 2 && nums[l - 1] == nums[l])
              l--;
          }

          while (i + 1 < nums.Length && nums[i + 1] == nums[i])
            i++;
        }


        return res;
      }
    }
  }
}
