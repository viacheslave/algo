using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3685/
  ///   
  /// </summary>
  internal class Mar26
  {
    public class Solution
    {
      public IList<string> WordSubsets(string[] A, string[] B)
      {
        var bmap = new Dictionary<char, int>();

        foreach (var bword in B)
        {
          foreach (var mapItem in GetChMap(bword))
          {
            if (!bmap.ContainsKey(mapItem.Key))
              bmap[mapItem.Key] = 0;

            bmap[mapItem.Key] = Math.Max(bmap[mapItem.Key], mapItem.Value);
          }
        }

        var ans = new List<string>();

        foreach (var aword in A)
        {
          var amap = GetChMap(aword);

          var ok = true;

          foreach (var bmapItem in bmap)
          {
            if (!amap.ContainsKey(bmapItem.Key) || amap[bmapItem.Key] < bmapItem.Value)
            {
              ok = false;
              break;
            }
          }

          if (ok)
            ans.Add(aword);

        }

        return ans;
      }

      private IDictionary<char, int> GetChMap(string s)
      {
        var map = new Dictionary<char, int>();

        foreach (var ch in s)
        {
          if (!map.ContainsKey(ch))
            map[ch] = 0;

          map[ch]++;
        }

        return map;
      }
    }
  }
}
