using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/586/week-3-february-15th-february-21st/3642/
  ///    
  /// </summary>
  internal class Feb16
  {
    public class Solution
    {
      public IList<string> LetterCasePermutation(string S)
      {
        var res = new List<string>();
        var sb = new StringBuilder();

        Rec(res, sb, S, 0);

        return res;
      }

      void Rec(List<string> res, StringBuilder sb, string S, int index)
      {
        if (index == S.Length)
        {
          res.Add(sb.ToString());
          return;
        }

        if (Char.IsDigit(S[index]))
        {
          sb.Append(S[index]);
          Rec(res, sb, S, index + 1);
          sb.Remove(sb.Length - 1, 1);
        }
        else
        {
          if (Char.IsLower(S[index]))
          {
            sb.Append(S[index]);
            Rec(res, sb, S, index + 1);
            sb.Remove(sb.Length - 1, 1);

            sb.Append(Char.ToUpper(S[index]));
            Rec(res, sb, S, index + 1);
            sb.Remove(sb.Length - 1, 1);
          }
          else
          {
            sb.Append(S[index]);
            Rec(res, sb, S, index + 1);
            sb.Remove(sb.Length - 1, 1);

            sb.Append(Char.ToLower(S[index]));
            Rec(res, sb, S, index + 1);
            sb.Remove(sb.Length - 1, 1);
          }
        }
      }
    }
  }
}
