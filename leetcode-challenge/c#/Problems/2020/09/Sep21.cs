using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.September.Challenge.Problems
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/556/week-3-september-15th-september-21st/3467/
  /// </summary>
  internal class Sep21
  {
    public class Solution
    {
      public bool CarPooling(int[][] trips, int capacity)
      {
        var picks = new SortedDictionary<int, int>();
        var drops = new SortedDictionary<int, int>();

        foreach (var trip in trips)
        {
          if (!picks.ContainsKey(trip[1]))
            picks[trip[1]] = 0;

          if (!drops.ContainsKey(trip[2]))
            drops[trip[2]] = 0;

          picks[trip[1]] += trip[0];
          drops[trip[2]] += trip[0];
        }

        var pickList = picks.Select(_ => (_.Key, _.Value)).ToList();
        var dropList = drops.Select(_ => (_.Key, _.Value)).ToList();

        var pickIndex = 0;
        var dropIndex = 0;

        var taken = 0;

        while (pickIndex < pickList.Count || dropIndex < dropList.Count)
        {
          if (taken > capacity)
            return false;

          if (pickIndex >= pickList.Count)
          {
            taken -= dropList[dropIndex].Value;
            dropIndex++;
            continue;
          }

          if (dropIndex >= dropList.Count)
          {
            taken += pickList[pickIndex].Value;
            pickIndex++;
            continue;
          }

          if (dropList[dropIndex].Key <= pickList[pickIndex].Key)
          {
            taken -= dropList[dropIndex].Value;
            dropIndex++;
          }
          else
          {
            taken += pickList[pickIndex].Value;
            pickIndex++;
          }
        }

        return true;
      }
    }
  }
}
