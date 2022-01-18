using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3709/
  /// 
  /// </summary>
  internal class Apr15
  {
    public class Solution
    {
      Dictionary<int, int> fib = new Dictionary<int, int>()
      {
          {1, 1},
          {2, 1},
          {3, 2}
      };

      public int Fib(int N)
      {

        if (N == 0)
          return 0;

        for (var i = 4; i <= N; i++)
        {
          fib[i] = fib[i - 1] + fib[i - 2];
        }


        return fib[N];
      }
    }
  }
}
