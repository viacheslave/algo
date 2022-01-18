using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3543/
  ///    https://leetcode.com/submissions/detail/423923372/?from=/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3543/
  /// </summary>
  internal class Nov25
  {
    public class Solution
    {
      public int SmallestRepunitDivByK(int K)
      {
        int module = 1 % K;
        if (module == 0)
          return 1;

        var length = 2;
        var modules = new HashSet<int>() { module };

        while (true)
        {
          module = (((module % K) * (10 % K)) % K + (1 % K)) % K;
          if (module == 0)
            return length;

          if (modules.Contains(module))
            return -1;

          modules.Add(module);
          length++;
        }
      }
    }
  }
}
