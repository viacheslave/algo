using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/meeting-rooms/
  ///    Submission: https://leetcode.com/submissions/detail/451185809/
  ///    All
  /// </summary>
  internal class P0252
  {
    public class Solution
    {
      public bool CanAttendMeetings(int[][] intervals)
      {
        var items = intervals
          .OrderBy(s => s[0])
          .ThenBy(s => s[1])
          .Select(s => (start: s[0], end: s[1]))
          .ToList();

        for (var i = 0; i < intervals.Length - 1; i++)
        {
          if (items[i].end <= items[i + 1].start)
            continue;

          return false;
        }

        return true;
      }
    }
  }
}
