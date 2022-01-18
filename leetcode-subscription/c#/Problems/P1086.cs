using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/high-five/
  ///    Submission: https://leetcode.com/submissions/detail/236085302/
  ///    Amazon
  /// </summary>
  internal class P1086
  {
    public class Solution
    {
      public int[][] HighFive(int[][] items)
      {
        var d = new Dictionary<int, List<int>>();

        foreach (var item in items)
        {
          if (!d.ContainsKey(item[0]))
            d[item[0]] = new List<int>();

          d[item[0]].Add(item[1]);
        }


        var d2 = new List<int[]>();

        foreach (var item in d)
        {
          int avg = 0;

          if (item.Value.Count >= 5)
            avg = item.Value.OrderByDescending(a => a).Take(5).Sum() / 5;
          else
            avg = item.Value.OrderByDescending(a => a).Sum() / item.Value.Count;

          d2.Add(new int[] { item.Key, avg });
        }

        return d2.ToArray();

      }
    }
  }
}
