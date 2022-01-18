using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/612/week-5-july-29th-july-31st/3833/
  /// 
  /// </summary>
  internal class Jul31
  {
    public class Solution
    {
      public int Trap(int[] height)
      {
        var ans = 0;
        var stack = new Stack<(int height, int pos)>();

        for (var i = 0; i < height.Length; i++)
        {
          var h = height[i];

          // if height descreases - just add it to stack
          if (stack.Count == 0 || h <= stack.Peek().height)
          {
            stack.Push((h, i));
            continue;
          }

          var current = stack.Pop();

          // search through stack for the most prev element with height
          // greater than next, and stop when it's greater than current 'h'
          while (stack.Count > 0 && stack.Peek().height >= current.height)
          {
            var hh = Math.Min(h, stack.Peek().height) - current.height;
            ans += hh * (i - stack.Peek().pos - 1);

            current = stack.Pop();

            if (current.height >= h)
            {
              stack.Push(current);
              break;
            }
          }

          stack.Push((h, i));
        }

        return ans;
      }
    }
  }
}
