using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3496/
  ///    https://leetcode.com/submissions/detail/408986143/?from=/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3496/
  /// </summary>
  internal class Oct15
  {
    public class Solution {
      public void Rotate(int[] nums, int k) {
          if (k == 0)
              return;
          
          if (nums.Length < 2)
              return;
          
          k = k % nums.Length;
          
          var saved = new int[k];
          
          for (var i = 0; i < k; i++)
              saved[i] = nums[nums.Length - k + i];
          
          for (var i = 0; i < nums.Length - k; i++)
              nums[nums.Length - 1 - i] = nums[nums.Length - 1 - i - k];
          
          for (var i = 0; i < k; i++)
              nums[i] = saved[i];
      }
    }
  }
}
