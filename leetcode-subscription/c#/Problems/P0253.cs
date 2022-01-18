using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/meeting-rooms-ii/
  ///    Submission: https://leetcode.com/submissions/detail/451187721/
  ///    All
  /// </summary>
  internal class P0253
  {
    public class Solution
    {
      public int MinMeetingRooms(int[][] intervals)
      {
        var items = intervals
          .SelectMany(i => new[] { (value: i[0], dir: 1), (value: i[1], dir: 0) })
          .OrderBy(i => i.value)
          .ThenBy(i => i.dir)
          .ToArray();

        var ans = 0;
        var current = 0;

        foreach (var item in items)
        {
          if (item.dir == 1)
            current++;
          else
            current--;

          ans = Math.Max(ans, current);
        }

        return ans;
      }
    }
  }
}
