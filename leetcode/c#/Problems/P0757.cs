namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/set-intersection-size-at-least-two/
///    Submission: https://leetcode.com/problems/set-intersection-size-at-least-two/submissions/865820296/
/// </summary>
internal class P0757
{
  public class Solution
  {
    public int IntersectionSizeTwo(int[][] intervals)
    {
      // greedy
      // the idea is to track ends
      // current end can eliminate many current intersecting intervals

      // order all starts and ends ascending
      var points = intervals
        .SelectMany((d, i) => new[] { (id: i, point: d[0], start: -1), (id: i, point: d[1], start: 1) })
        .OrderBy(d => d.point)
        .ThenBy(d => d.start)
        .ToArray();

      var arr = new List<int>();
      var lines = new SortedSet<int>();
      var processed = new HashSet<int>();

      foreach (var point in points)
      {
        // start - only add to current list of intervals
        if (point.start == -1)
        {
          lines.Add(point.id);
          continue;
        }

        // end - if no current pending intervals, skip it
        if (lines.Count == 0)
        {
          continue;
        }

        // end - track what's processed
        if (processed.Contains(point.id))
        {
          continue;
        }

        var rem = new List<int>();

        // we add current end to arr
        // also we probably add point-1 to cover more intervals
        // point-1 can be skipped because we can use last arr point

        var lastPoint = (arr.Count == 0) ? -1 : arr[^1];
        var secondPoint = lastPoint;

        var pair = (from: lastPoint, to: point.point);

        foreach (var line in lines)
        {
          if (intervals[line][1] == point.point && intervals[line][0] > lastPoint)
          {
            secondPoint = point.point - 1;
            break;
          }
        }

        if (lastPoint != secondPoint)
        {
          pair = (secondPoint, point.point);
          arr.Add(secondPoint);
        }

        arr.Add(point.point);

        // remove eligible intervals
        // add to processed

        foreach (var line in lines)
        {
          if (intervals[line][0] <= arr[^2] && arr[^1] <= intervals[line][1])
          {
            rem.Add(line);
          }
        }

        foreach (var item in rem)
        {
          lines.Remove(item);
          processed.Add(item);
        }
      }

      return arr.Count;
    }
  }

}
