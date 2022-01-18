using System;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///	  https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/552/week-4-august-22nd-august-28th/3433/
  ///	  https://leetcode.com/submissions/detail/384542476/?from=/explore/challenge/card/august-leetcoding-challenge/552/week-4-august-22nd-august-28th/3433/
  /// </summary>
  internal class Aug22
  {
    public class Solution
    {
      private readonly int[][] _rects;
      private readonly int _count;
      private readonly Random _random = new Random();

      public Solution(int[][] rects)
      {
        _rects = rects;

        var count = 0;
        foreach (var rect in rects)
          count += (rect[2] - rect[0] + 1) * (rect[3] - rect[1] + 1);

        _count = count;
      }

      public int[] Pick()
      {
        var rnd = _random.Next(_count);

        var area = 0;
        var rectIndex = 0;

        while (rnd >= area)
        {
          area +=
              (_rects[rectIndex][2] - _rects[rectIndex][0] + 1) *
              (_rects[rectIndex][3] - _rects[rectIndex][1] + 1);
          rectIndex++;
        }

        rectIndex--;

        area -=
                (_rects[rectIndex][2] - _rects[rectIndex][0] + 1) *
                (_rects[rectIndex][3] - _rects[rectIndex][1] + 1);


        var relativeIndex = rnd - area;

        var rows = _rects[rectIndex][3] - _rects[rectIndex][1] + 1;

        var xShift = relativeIndex / rows;
        var yShift = relativeIndex % rows;

        return new int[] { _rects[rectIndex][0] + xShift, _rects[rectIndex][1] + yShift };
      }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(rects);
     * int[] param_1 = obj.Pick();
     */
  }
}
