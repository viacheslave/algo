using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3421/
  ///    https://leetcode.com/submissions/detail/379932679/?from=/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3421/
  /// </summary>
  internal class Aug12
  {
    public class Solution
    {
      public IList<int> GetRow(int rowIndex)
      {
        List<IList<int>> result = new List<IList<int>>();

        for (var i = 0; i <= rowIndex; i++)
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

        return result[result.Count - 1];
      }
    }
  }
}
