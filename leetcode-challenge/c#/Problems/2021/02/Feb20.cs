using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/586/week-3-february-15th-february-21st/3646/
  ///    
  /// </summary>
  internal class Feb20
  {
    public class Solution
    {
      public int RomanToInt(string s)
      {
        int m = 0,
            d = 0,
            c = 0, l = 0, x = 0, v = 0, i = 0;

        for (var a = 0; a < s.Length; a++)
        {
          if (s[a] == 'M') m += 1000;
          if (s[a] == 'D') d += 500;

          if (s[a] == 'C')
          {
            if ((a + 1) < s.Length && (s[a + 1] == 'D' || s[a + 1] == 'M'))
            {
              c -= 100;
            }
            else
            {
              c += 100;
            }
          }

          if (s[a] == 'L') l += 50;

          if (s[a] == 'X')
          {
            if ((a + 1) < s.Length && (s[a + 1] == 'L' || s[a + 1] == 'C'))
            {
              x -= 10;
            }
            else
            {
              x += 10;
            }
          }


          if (s[a] == 'V') v += 5;
          if (s[a] == 'I')
          {
            if ((a + 1) < s.Length && (s[a + 1] == 'V' || s[a + 1] == 'X'))
            {
              i -= 1;
            }
            else
            {
              i += 1;
            }
          }
        }

        return (m + d + c + l + x + v + i);
      }
    }
  }
}
