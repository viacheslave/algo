using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/range-addition/
  ///    Submission: https://leetcode.com/submissions/detail/453261836/
  ///    Google
  /// </summary>
  internal class P0370
  {
    public class Solution
    {
      public int[] GetModifiedArray(int length, int[][] updates)
      {
        var u = new List<(int index, int inc)>();

        foreach (var upd in updates)
        {
          u.Add((upd[0], upd[2]));
          u.Add((upd[1] + 1, -upd[2]));
        }

        var dict = u.GroupBy(x => x.index)
          .ToDictionary(x => x.Key, x => x.Select(c => c.inc).Sum());

        var inc = 0;
        var ans = new int[length];

        for (var i = 0; i < length; i++)
        {
          if (dict.ContainsKey(i))
            inc += dict[i];

          ans[i] = inc;
        }

        return ans;
      }
    }
  }
}
