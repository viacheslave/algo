using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/606/week-4-june-22nd-june-28th/3794/
  /// 
  /// </summary>
  internal class Jun28
  {
    public class Solution
    {
      public string RemoveDuplicates(string S)
      {
        if (S.Length < 2)
          return S;

        var sb = new StringBuilder(S);

        while (true)
        {
          if (S.Length < 2)
            return sb.ToString();

          var pos = -1;
          for (var i = 1; i < sb.Length; i++)
          {
            if (sb[i] == sb[i - 1])
            {
              pos = i - 1;
              break;
            }
          }

          if (pos == -1)
            break;

          sb.Remove(pos, 2);

        }

        return sb.ToString();
      }
    }
  }
}
