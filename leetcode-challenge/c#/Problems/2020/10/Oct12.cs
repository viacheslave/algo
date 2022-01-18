using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/560/week-2-october-8th-october-14th/3492/
  ///    https://leetcode.com/submissions/detail/407686949/?from=/explore/challenge/card/october-leetcoding-challenge/560/week-2-october-8th-october-14th/3492/
  /// </summary>
  internal class Oct12
  {
    public class Solution
    {
      public bool BuddyStrings(string A, string B)
      {
        if (A == null || B == null)
          return false;

        if (A.Length != B.Length)
          return false;

        var i1 = -1;
        var i2 = -1;

        var hs = new HashSet<char>();

        var eq = A == B;

        for (var i = 0; i < A.Length; i++)
        {
          if (eq && hs.Contains(A[i]))
            return true;

          hs.Add(A[i]);

          if (A[i] != B[i])
          {
            if (i1 == -1)
              i1 = i;
            else if (i2 == -1)
              i2 = i;
            else return false;
          }
        }

        return (i1 >= 0 && i2 >= 0)
            && (A[i1] == B[i2]) && (A[i2] == B[i1]);
      }
    }
  }
}
