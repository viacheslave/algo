using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/585/week-2-february-8th-february-14th/3639/
  ///    
  /// </summary>
  internal class Feb14
  {
    public class Solution
    {
      public bool IsBipartite(int[][] graph)
      {
        var pool = graph
            .Select((x, i) => (x, i))
            .OrderByDescending(x => x.x.Length)
            .ToDictionary(x => x.i, x => x.x);

        var nodes = new Dictionary<int, bool>();

        var q = new Queue<(int key, bool color)>();
        q.Enqueue((key: pool.First().Key, color: true));

        while (q.Count > 0)
        {
          var item = q.Dequeue();
          if (nodes.ContainsKey(item.key))
          {
            if (nodes[item.key] == item.color)
              continue;

            return false;
          }

          var edges = pool[item.key];

          nodes[item.key] = item.color;

          foreach (var edge in pool[item.key])
          {
            q.Enqueue((edge, !item.color));
          }
        }

        return true;
      }
    }
  }
}
