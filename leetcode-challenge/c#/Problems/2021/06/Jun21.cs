using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/605/week-3-june-15th-june-21st/3786/
  /// 
  /// </summary>
  internal class Jun21
  {
    public class Solution
    {
      public IList<IList<int>> Generate(int numRows)
      {
        List<IList<int>> result = new List<IList<int>>();

        for (var i = 0; i < numRows; i++)
        {
          List<int> arr = new List<int>() { 1 };

          for (var j = 1; j < i + 1; j++)
          {
            var left = result[i - 1][j - 1];
            var right = result[i - 1].Count > j ? result[i - 1][j] : 0;

            arr.Add(left + right);
          }

          result.Add(arr);
        }

        return result;
      }
    }
  }
}
