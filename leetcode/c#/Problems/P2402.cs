namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/meeting-rooms-iii/
///    Submission: https://leetcode.com/submissions/detail/796296152/
/// </summary>
internal class P2402
{
  public class Solution
  {
    public record Used(long endTime, int room) : IComparable<Used>
    {
      public int CompareTo(Used other)
      {
        if (endTime == other.endTime)
          return room.CompareTo(other.room);

        return endTime.CompareTo(other.endTime);
      }
    }

    public int MostBooked(int n, int[][] meetings)
    {
      // keep available rooms in PQ
      // keep in-progress meetings in PQ

      var rooms = new PriorityQueue<int, int>(
        Enumerable.Range(0, n).Select(i => (i, i)));

      var used = new PriorityQueue<Used, Used>();

      var meets = meetings.OrderBy(m => m[0]).ToArray();

      var stats = new int[n];
      var currentTime = 0L;

      for (var i = 0; i < meets.Length; i++)
      {
        var meet = meets[i];
        var start = meet[0];
        var end = meet[1];
        var dur = meet[1] - meet[0];

        // if next meeting start time is greater - adjust current time 
        if (start > currentTime)
        {
          currentTime = start;
        }

        // get all finished meetings by current time
        // put freed rooms back into PQ

        while (used.Count > 0 && used.Peek().endTime <= currentTime)
        {
          var (endtime, r) = used.Dequeue();
          rooms.Enqueue(r, r);
        }

        var room = 0;

        if (rooms.Count > 0)
        {
          room = rooms.Dequeue();
        }
        else
        {
          // otherwise - get first room to free
          var (endtime, r) = used.Dequeue();
          currentTime = endtime;
          room = r;
        }

        var usedRecord = new Used(currentTime + dur, room);
        used.Enqueue(usedRecord, usedRecord);
        stats[room]++;
      }

      var max = stats.Max();
      return stats.Select((y, i) => (y, i)).First(d => d.y == max).i;
    }
  }
}
