using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/601/week-4-may-22nd-may-28th/3757/
  /// 
  /// </summary>
  internal class May27
  {
    public class Solution
    {
      public int MaxProduct(string[] words)
      {
        var map = new Dictionary<string, int>();
        foreach (var word in words)
        {
          var value = 0;
          foreach (var ch in word.Distinct().ToHashSet())
            value += (int)Math.Pow(2, ch - 97);

          map[word] = value;
        }

        var values = map.ToList();
        var max = 0;

        for (var i = 0; i < values.Count; i++)
          for (var j = 1; j < values.Count; j++)
            if ((values[i].Value & values[j].Value) == 0)
              max = Math.Max(max, values[i].Key.Length * values[j].Key.Length);

        return max;
      }
    }
  }
}
