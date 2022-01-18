using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/601/week-4-may-22nd-may-28th/3754/
  /// 
  /// </summary>
  internal class May24
  {
    public class Solution
    {
      public string ToLowerCase(string str)
      {
        var chars = new char[str.Length];

        for (var i = 0; i < str.Length; i++)
          chars[i] = ((int)str[i] >= 65 && (int)str[i] <= 91) ? (char)((int)str[i] + 32) : str[i];

        return new string(chars);
      }
    }
  }
}
