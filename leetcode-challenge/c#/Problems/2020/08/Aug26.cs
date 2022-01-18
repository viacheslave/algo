using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///	  https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/552/week-4-august-22nd-august-28th/3437/
  ///	  https://leetcode.com/submissions/detail/386703937/?from=/explore/challenge/card/august-leetcoding-challenge/552/week-4-august-22nd-august-28th/3437/
  /// </summary>
  internal class Aug26
  {
    public class Solution
    {
      public IList<string> FizzBuzz(int n)
      {
        var list = new List<string>(n);

        for (var i = 1; i <= n; i++)
        {
          if (i % 15 == 0)
            list.Add("FizzBuzz");
          else if (i % 5 == 0)
            list.Add("Buzz");
          else if (i % 3 == 0)
            list.Add("Fizz");
          else
            list.Add(i.ToString());
        }

        return list;
      }
    }
  }
}
