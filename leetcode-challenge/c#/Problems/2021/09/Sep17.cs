using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3978/
  /// 
  /// </summary>
  internal class Sep17
  {
    public class Solution
    {
      public int[] Intersect(int[] nums1, int[] nums2)
      {
        var a1 = new Dictionary<int, int>();

        foreach (var a in nums1)
        {
          if (!a1.ContainsKey(a))
            a1[a] = 0;

          a1[a]++;
        }

        var res = new List<int>();
        foreach (var a in nums2)
        {
          if (a1.ContainsKey(a))
          {
            res.Add(a);
            a1[a]--;

            if (a1[a] == 0)
              a1.Remove(a);
          }
        }

        return res.ToArray();
      }
    }
  }
}
