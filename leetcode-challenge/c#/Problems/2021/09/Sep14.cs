using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/3974/
  /// 
  /// </summary>
  internal class Sep14
  {
    public class Solution
    {
      public string ReverseOnlyLetters(string S)
      {
        var ch = new char[S.Length];

        for (var i = 0; i < S.Length; i++)
          if (!Char.IsLetter(S[i]))
            ch[i] = S[i];

        int chIndex = 0;
        int sIndex = S.Length - 1;

        while (sIndex >= 0)
        {
          while (sIndex >= 0 && !Char.IsLetter(S[sIndex]))
            sIndex--;

          while (chIndex < ch.Length && ch[chIndex] != default)
            chIndex++;

          if (sIndex < 0 || chIndex >= ch.Length)
            break;

          ch[chIndex++] = S[sIndex--];
        }

        return new string(ch);
      }
    }
  }
}
