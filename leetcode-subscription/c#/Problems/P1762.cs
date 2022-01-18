using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/buildings-with-an-ocean-view/
  ///    Submission: https://leetcode.com/submissions/detail/461706168/
  ///    Facebook
  /// </summary>
  internal class P1762
  {
    public class Solution
    {
      public int[] FindBuildings(int[] heights)
      {
        Array.Reverse(heights);

        var st = new Stack<(int height, int index)>();
        for (var i = 0; i < heights.Length; i++)
        {
          var h = heights[i];
          if (st.Count == 0 || (st.Count > 0 && h > st.Peek().height))
            st.Push((h, heights.Length - i - 1));
        }

        return st.Select(x => x.index).ToArray();
      }
    }
  }
}
