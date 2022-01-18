using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/616/week-4-august-22nd-august-28th/3918/
  /// 
  /// </summary>
  internal class Aug25
  {
    public class Solution
    {
      public bool JudgeSquareSum(int c)
      {
        var sqs = new HashSet<int>() { 0 };

        var current = 1;
        var addition = 3;

        while (current <= c)
        {
          sqs.Add(current);

          if (c - addition < current)
            break;

          current += addition;
          addition += 2;
        }


        foreach (var sq in sqs)
        {
          if (sqs.Contains(c - sq))
            return true;
        }

        return false;
      }
    }
  }
}
