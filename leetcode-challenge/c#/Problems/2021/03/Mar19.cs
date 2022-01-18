using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-3-march-15th-march-21st/3677/
  ///   
  /// </summary>
  internal class Mar19
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
}
