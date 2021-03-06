namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/keys-and-rooms/
///    Submission: https://leetcode.com/submissions/detail/239543780/
/// </summary>
internal class P0841
{
  public class Solution
  {
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
      var edges = new HashSet<(int, int)>();
      var queue = new Queue<int>();
      var vrooms = new HashSet<int>();

      queue.Enqueue(0);

      while (queue.Count > 0)
      {
        var room = queue.Dequeue();
        vrooms.Add(room);

        foreach (var nextRoom in rooms[room])
        {
          if (edges.Contains((room, nextRoom)))
            continue;

          edges.Add((room, nextRoom));
          queue.Enqueue(nextRoom);
        }
      }

      return vrooms.Count == rooms.Count;
    }
  }
}
