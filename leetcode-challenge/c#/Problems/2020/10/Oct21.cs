using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3502/
  ///    https://leetcode.com/submissions/detail/411371952/?from=/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3502/
  /// </summary>
  internal class Oct21
  {
    public class Solution
    {
      public int[] AsteroidCollision(int[] asteroids)
      {
        if (asteroids.Length <= 1)
          return asteroids;

        var left = 0;
        var right = 1;

        var list = asteroids.ToList();

        while (true)
        {
          if (list.Count <= 1)
            break;

          if (!(list[left] > 0 && list[right] < 0))
          {
            left++;
            right++;
            if (right >= list.Count)
              break;

            continue;
          }

          var result = 0;
          if (list[left] > Math.Abs(list[right]))
            result = list[left];
          else if (list[left] < Math.Abs(list[right]))
            result = list[right];
          else
            result = 0;

          // elimination
          if (result == 0)
          {
            list.RemoveAt(left);
            list.RemoveAt(left);
            left--;

            if (left < 0) left = 0;
            right = left + 1;
          }
          else if (result > 0)
          {
            list.RemoveAt(right);
          }
          else
          {
            list.RemoveAt(left);
            left--;

            if (left < 0) left = 0;
            right = left + 1;
          }

          if (right >= list.Count)
            break;
        }

        return list.ToArray();
      }
    }
  }
}
