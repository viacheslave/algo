using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3701/
  /// 
  /// </summary>
  internal class Apr08
  {
    public class Solution
    {
      Dictionary<int, char[]> map = new Dictionary<int, char[]>
        {
            {2, new char[] {'a','b','c'}},
            {3, new char[] {'d','e','f'}},
            {4, new char[] {'g','h','i'}},
            {5, new char[] {'j','k','l'}},
            {6, new char[] {'m','n','o'}},
            {7, new char[] {'p','q','r', 's'}},
            {8, new char[] {'t','u','v'}},
            {9, new char[] {'w','x','y', 'z'}}
        };



      public IList<string> LetterCombinations(string digits)
      {
        var len = digits.Length;

        var res = new List<string>();
        if (len == 0)
          return res;

        var cur = new char[len];

        Process(digits, res, cur, 0);

        return res;
      }

      private void Process(string digits, List<string> res, char[] cur, int index)
      {
        if (index == cur.Length)
        {
          res.Add(new string(cur));
          return;
        }

        var number = int.Parse(digits[index].ToString());
        var arr = map[number];

        for (var i = 0; i < arr.Length; i++)
        {
          cur[index] = arr[i];
          Process(digits, res, cur, index + 1);
        }
      }
    }
  }
}
