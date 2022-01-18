using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/601/week-4-may-22nd-may-28th/3755/
  /// 
  /// </summary>
  internal class May25
  {
    public class Solution
    {
      public int EvalRPN(string[] tokens)
      {
        var st = new Stack<object>();
        var operators = new HashSet<string>() { "+", "-", "*", "/" };

        foreach (var token in tokens)
        {
          if (operators.Contains(token))
          {
            var op2 = (int)st.Pop();
            var op1 = (int)st.Pop();

            switch (token)
            {
              case "+": st.Push(op1 + op2); break;
              case "-": st.Push(op1 - op2); break;
              case "*": st.Push(op1 * op2); break;
              case "/": st.Push(op1 / op2); break;
            }
          }
          else
          {
            st.Push(int.Parse(token));
          }
        }

        return (int)st.Pop();
      }
    }
  }
}
