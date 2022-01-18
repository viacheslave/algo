using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3705/
  /// 
  /// </summary>
  internal class Apr12
  {
    public class Solution
    {
      public int[] ConstructArray(int n, int k)
      {
        var ans = new List<int>();

        for (var i = 1; i <= n - k; i++)
          ans.Add(i);

        if (ans.Count == n)
          return ans.ToArray();

        ans.Add(n);

        var left = n - k;
        var right = n;
        var dir = -1;

        while (ans.Count != n)
        {
          if (dir < 0)
          {
            ans.Add(left + 1);
            left++;
          }
          else
          {
            ans.Add(right - 1);
            right--;
          }

          dir = -dir;
        }

        return ans.ToArray();
      }
    }
  }
}
