using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3420/
  ///    https://leetcode.com/submissions/detail/379275922/?from=/explore/challenge/card/august-leetcoding-challenge/550/week-2-august-8th-august-14th/3420/
  /// </summary>
  internal class Aug11
  {
    public class Solution
    {
      public int HIndex(int[] citations)
      {
        if (citations.Length == 0)
          return 0;

        Array.Sort(citations);

        for (var i = citations.Length - 1; i >= 0; i--)
        {
          var leftIndex = i == 0 ? 0 : citations[i - 1];
          var rightIndex = Math.Min(citations.Length - i, citations[i]);

          if (leftIndex > rightIndex)
            continue;

          return rightIndex;
        }

        return 1;
      }
    }
  }
}
