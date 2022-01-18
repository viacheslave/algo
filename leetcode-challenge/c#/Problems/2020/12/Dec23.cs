using System;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/572/week-4-december-22nd-december-28th/3578/
  ///    https://leetcode.com/submissions/detail/433644504/?from=explore&item_id=3578
  /// </summary>
  internal class Dec23
  {
    public class Solution
    {
      public int NextGreaterElement(int n)
      {
        var ch = n.ToString().Select(_ => int.Parse(_.ToString())).ToList();
        if (ch.Count == 1)
          return -1;

        for (var i = ch.Count - 2; i >= 0; i--)
        {
          var maxIndex = -1;
          var minValue = int.MaxValue;

          for (var j = i + 1; j < ch.Count; j++)
          {
            if (ch[j] > ch[i])
            {
              if (ch[j] < minValue)
              {
                minValue = ch[j];
                maxIndex = j;
              }
            }
          }

          if (maxIndex == -1)
            continue;

          // swap
          var tmp = ch[i];
          ch[i] = ch[maxIndex];
          ch[maxIndex] = tmp;

          // order last
          var f = ch.Take(i + 1).ToList();
          var l = ch.Skip(i + 1).OrderBy(_ => _);
          ch = f.Concat(l).ToList();

          try
          {
            return int.Parse(string.Join("", ch.Select(_ => _.ToString())));
          }
          catch (OverflowException)
          {
            return -1;
          }

        }

        return -1;
      }
    }
  }
}
