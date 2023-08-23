namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/course-schedule-iii/
///    Submission: https://leetcode.com/submissions/detail/729349710/
/// </summary>
internal class P0630
{
  public class Solution
  {
    public int ScheduleCourse(int[][] courses)
    {
      // greedy
      // greedily take the courses (sorted by end) until possible
      // if impossible - kick out the largest course and take the next (it fits now)
      // pq - for determining largest courses

      var ccs = courses
        .Select(c => new Item(start: c[1] - c[0] + 1, duration: c[0], end: c[1]))
        .OrderBy(x => x.end)
        .ToArray();

      var added = new PriorityQueue<Item, Item>();
      var currentTime = 1;

      for (int i = 0; i < ccs.Length; i++)
      {
        var cc = new Item(ccs[i].start, ccs[i].duration, ccs[i].end);

        if (currentTime <= cc.start)
        {
          currentTime += cc.duration;
          added.Enqueue(cc, cc);

          continue;
        }

        if (added.Count > 0 && added.Peek().duration > cc.duration)
        {
          var peek = added.Dequeue();

          currentTime -= peek.duration;
          currentTime += cc.duration;

          added.Enqueue(cc, cc);
        }
      }

      return added.Count;
    }

    private record Item(int start, int duration, int end) : IComparable<Item>
    {
      public int CompareTo(Item other) => other.duration.CompareTo(this.duration);
    }
  }

}
