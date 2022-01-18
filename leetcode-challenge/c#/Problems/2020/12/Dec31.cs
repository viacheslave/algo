using System;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/573/week-5-december-29th-december-31st/3587/
  ///    https://leetcode.com/submissions/detail/436745713/?from=explore&item_id=3587
  /// </summary>
  internal class Dec31
  {
    public class Solution
    {
      public int LargestRectangleArea(int[] heights)
      {
        var ans = 0;

        if (heights.Length == 0)
          return 0;

        for (var i = 0; i < heights.Length; i++)
        {
          ans = Math.Max(ans, heights[i]);
          var min = heights[i];

          for (var j = i - 1; j >= 0; j--)
          {
            if (heights[j] == 0)
              break;

            min = Math.Min(min, heights[j]);
            ans = Math.Max(ans, ((i - j) + 1) * min);
          }
        }

        return ans;
      }
    }
  }
}
