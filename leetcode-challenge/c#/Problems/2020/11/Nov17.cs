using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3534/
  ///    
  /// </summary>
  internal class Nov17
  {
    public class Solution
    {
      public int MirrorReflection(int p, int q)
      {
        if (q == 0)
          return 0;

        var qpos = 0;
        for (var i = 0; ; i++)
        {
          qpos += q;
          if (qpos % p == 0)
          {
            if (i % 2 == 1)
              return 2;
            else
            {
              var div = qpos / p;
              if (div % 2 == 0)
                return 0;
              return 1;
            }
          }
        }

        return -1;
      }
    }

  }
}
