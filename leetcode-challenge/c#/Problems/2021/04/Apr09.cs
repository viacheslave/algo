using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3702/
  /// 
  /// </summary>
  internal class Apr09
  {
    public class Solution
    {
      public bool IsAlienSorted(string[] words, string order)
      {
        var newList = new List<string>();

        foreach (var word in words)
        {
          var sb = new StringBuilder();

          foreach (var ch in word)
            sb.Append((char)(97 + order.IndexOf(ch)));

          newList.Add(sb.ToString());
        }

        var orderedList = newList.OrderBy(_ => _).ToList();

        for (var i = 0; i < newList.Count; i++)
          if (newList[i] != orderedList[i])
            return false;

        return true;
      }
    }
  }
}
