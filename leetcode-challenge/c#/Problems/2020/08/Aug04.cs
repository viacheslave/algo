using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3412/
  ///    https://leetcode.com/submissions/detail/375888352/?from=/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3412/
  /// </summary>
  internal class Aug04
  {
    public class Solution
    {
      public bool IsPowerOfFour(int num)
      {
        var str = Convert.ToString(num, 2);

        if (str[0] == '1')
        {
          if (str.Skip(1).All(ch => ch == '0') && (str.Length - 1) % 2 == 0)
          {
            return true;
          }
        }

        return false;
      }
    }
  }
}
