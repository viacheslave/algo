using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/601/week-4-may-22nd-may-28th/3756/
  /// 
  /// </summary>
  internal class May26
  {
    public class Solution
    {
      public int MinPartitions(string n)
      {
        return n.Select(_ => int.Parse(_.ToString())).Max();
      }
    }
  }
}
