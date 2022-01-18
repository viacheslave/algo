using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///	  https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/552/week-4-august-22nd-august-28th/3439/
  ///	  https://leetcode.com/submissions/detail/387542195/?from=/explore/challenge/card/august-leetcoding-challenge/552/week-4-august-22nd-august-28th/3439/
  /// </summary>
  internal class Aug28
  {
    /**
    * The Rand7() API is already defined in the parent class SolBase.
    * public int Rand7();
    * @return a random integer in the range 1 to 7
    */
    public class Solution : SolBase
    {
      public int Rand10()
      {
        var r1 = Rand7() - 1;
        var r2 = Rand7() - 1;

        var value49 = r1 * 7 + r2;
        if (value49 < 40)
          return (value49 % 10) + 1;

        r1 = value49 - 40;
        r2 = Rand7() - 1;

        var value63 = r1 * 7 + r2;
        if (value63 < 60)
          return (value63 % 10) + 1;

        r1 = value63 - 60;
        r2 = Rand7() - 1;

        return (r1 + r2) + 1;
      }
    }

    internal class SolBase
    {
      public int Rand7() { throw new NotImplementedException(); }
    }
  }
}
