using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3569/
  ///    https://leetcode.com/submissions/detail/431583953/?from=explore&item_id=3569
  /// </summary>
  internal class Dec17
  {
    public class Solution
    {
      public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
      {
        var length = A.Length;

        // compress to two sequences
        var a = new int[length * length];
        var b = new int[length * length];

        for (int i = 0; i < length; i++)
        {
          for (int j = 0; j < length; j++)
          {
            a[i * length + j] = A[i] + B[j];
            b[i * length + j] = C[i] + D[j];
          }
        }

        // create hashmaps of value -> count of that value
        var map_a = a.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count());
        var map_b = b.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count());

        var sorted_a = map_a.Keys.OrderBy(_ => _).ToArray();
        var sorted_b = map_b.Keys.OrderBy(_ => _).ToArray();

        var ans = 0;

        var ai = 0;
        var bi = sorted_b.Length - 1;

        // two pointers
        while (ai < sorted_a.Length)
        {
          while (bi >= 0 && sorted_a[ai] + sorted_b[bi] >= 0)
          {
            if (sorted_a[ai] + sorted_b[bi] == 0)
            {
              ans += map_a[sorted_a[ai]] * map_b[sorted_b[bi]];
              break;
            }

            bi--;
          }

          if (bi < 0)
            break;

          ai++;
        }

        return ans;
      }
    }
  }
}
