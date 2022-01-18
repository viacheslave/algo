using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3669/
  ///   
  /// </summary>
  internal class Mar12
  {
    public class Solution
    {
      public bool HasAllCodes(string s, int k)
      {
        var codes = new HashSet<string>();

        for (int i = 0; i < s.Length - k + 1; i++)
        {
          var code = s.Substring(i, k);
          if (!codes.Contains(code))
            codes.Add(code);
        }

        return codes.Count == Math.Pow(2, k);
      }
    }
  }
}
