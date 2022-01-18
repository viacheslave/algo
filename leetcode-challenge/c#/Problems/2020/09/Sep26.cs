using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.September.Challenge.Problems
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/557/week-4-september-22nd-september-28th/3473/
  ///    https://leetcode.com/submissions/detail/400863436/?from=/explore/challenge/card/september-leetcoding-challenge/557/week-4-september-22nd-september-28th/3473/
  /// </summary>
  internal class Sep26
  {
    public class Solution
    {
      public int FindPoisonedDuration(int[] timeSeries, int duration)
      {
        if (timeSeries.Length == 0 || duration == 0)
          return 0;

        var total = 0;

        var start = -1;
        var end = -1;

        for (var i = 0; i < timeSeries.Length - 1; i++)
        {
          if (start == -1)
          {
            start = timeSeries[i];
            end = timeSeries[i] + duration - 1;
          }

          if (end >= timeSeries[i + 1])
            continue;

          var endOnDuration = timeSeries[i] + duration - 1;
          var endMax = Math.Max(end, endOnDuration);

          if (endMax >= timeSeries[i + 1])
            continue;

          total += (endMax - start) + 1;
          start = -1;
          end = -1;
        }

        if (end == -1)
        {
          total += duration;
        }
        else
        {
          var endOnDuration = timeSeries[timeSeries.Length - 1] + duration - 1;
          var endMax = Math.Max(end, endOnDuration);

          total += (endMax - start) + 1;
        }

        return total;

      }
    }
  }
}
