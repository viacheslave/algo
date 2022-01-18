using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3651/
  ///   
  /// </summary>
  internal class Feb24
  {
    public class Solution
    {
      public int ScoreOfParentheses(string S)
      {
        // (()(()))

        var stack = new Stack<int>();
        var score = 0;

        for (int i = 0; i < S.Length; i++)
        {
          var ch = S[i];

          if (ch == '(')
          {
            stack.Push(score);
            score = 0;
          }

          if (ch == ')')
          {
            var popScore = stack.Pop();
            score = popScore + (score == 0 ? 1 : score * 2);
          }
        }

        return score;
      }
    }
  }
}
