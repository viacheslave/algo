using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/586/week-3-february-15th-february-21st/3643/
  ///    
  /// </summary>
  internal class Feb17
  {
    public class Solution
    {
      public int MaxArea(int[] height)
      {
        var i = 0;
        var j = height.Length - 1;

        var area = 0;
        var maxArea = 0;

        while (i < j)
        {
          area = (j - i) * Math.Min(height[j], height[i]);
          if (maxArea < area)
            maxArea = area;

          if (height[i] < height[j])
            i++;
          else
            j--;
        }

        return maxArea;
      }
    }
  }
}
