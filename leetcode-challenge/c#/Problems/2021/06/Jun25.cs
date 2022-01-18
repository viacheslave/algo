using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/606/week-4-june-22nd-june-28th/3791/
  /// 
  /// </summary>
  internal class Jun25
  {
    public class Solution
    {
      public int[] FindRedundantConnection(int[][] edges)
      {
        var islands = new List<HashSet<int>>();
        int[] redundant = null;

        for (int i = 0; i < edges.Length; i++)
        {
          var edge = edges[i];

          var isl = new List<int>(2);
          for (int j = 0; j < islands.Count; j++)
          {
            if (islands[j].Contains(edge[0]))
              isl.Add(j);
            if (islands[j].Contains(edge[1]))
              isl.Add(j);
          }

          if (isl.Count == 0)
          {
            islands.Add(new HashSet<int>(new int[] { edge[0], edge[1] }));
            continue;
          }

          if (isl.Count == 1)
          {
            islands[isl[0]].Add(edge[0]);
            islands[isl[0]].Add(edge[1]);
            continue;
          }

          if (isl[0] == isl[1])
          {
            redundant = edge;
            continue;
          }

          MergeIslands(islands, isl[0], isl[1]);
        }

        return redundant;
      }

      private void MergeIslands(List<HashSet<int>> islands, int index1, int index2)
      {
        islands[index1] = new HashSet<int>(islands[index1].Concat(islands[index2]));
        islands.RemoveAt(index2);
      }
    }
  }
}
