using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3653/
  ///   
  /// </summary>
  internal class Feb26
  {
    public class Solution
    {
      public bool ValidateStackSequences(int[] pushed, int[] popped)
      {
        Stack<int> s = new Stack<int>();

        var pu = 0;
        var po = 0;

        while (po < popped.Length)
        {
          if (s.Count == 0 || s.Peek() != popped[po])
          {
            if (pu >= pushed.Length)
              return false;

            s.Push(pushed[pu]);
            pu++;
            continue;
          }

          if (po >= popped.Length)
            return false;

          if (s.Peek() == popped[po])
          {
            s.Pop();
            po++;
          }
        }

        return true;
      }
    }
  }
}
