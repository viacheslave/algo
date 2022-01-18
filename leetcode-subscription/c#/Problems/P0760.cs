using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-anagram-mappings/
  ///    Submission: https://leetcode.com/submissions/detail/451189638/
  ///    Google
  /// </summary>
  internal class P0760
  {
    public class Solution
    {
      public int[] AnagramMappings(int[] A, int[] B)
      {
        var mapping = B.Select((b, i) => (i, b))
          .GroupBy(t => t.b)
          .ToDictionary(t => t.Key, t => t.Select(e => e.i).ToHashSet());

        var ans = new int[B.Length];

        for (var i = 0; i < A.Length; i++)
        {
          var ch = A[i];
          var j = mapping[ch].First();

          ans[i] = j;
          mapping[ch].Remove(j);
        }

        return ans;
      }
    }
  }
}
