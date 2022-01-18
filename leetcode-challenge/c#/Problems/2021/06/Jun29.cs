using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/607/week-5-june-29th-june-30th/3796/
  /// 
  /// </summary>
  internal class Jun29
  {
    public class Solution
    {
      public int LongestOnes(int[] A, int K)
      {
        var ans = 0;

        var ws = 0;
        var we = 0;

        var zs = -1;
        var ze = -1;

        var zerosIndexes = new List<int>();
        for (int i = 0; i < A.Length; i++)
          if (A[i] == 0)
            zerosIndexes.Add(i);

        if (K == 0)
        {
          zerosIndexes.Insert(0, -1);
          zerosIndexes.Add(A.Length);

          for (int i = 0; i < zerosIndexes.Count - 1; i++)
            ans = Math.Max(ans, Math.Abs(zerosIndexes[i] - zerosIndexes[i + 1]) - 1);

          return ans;
        }

        while (we != A.Length - 1)
        {
          if (ze == -1)
            ze = K - 1;
          else
            ze++;

          if (ze > zerosIndexes.Count - 1)
            return A.Length;

          zs = ze - K + 1;

          ws = zerosIndexes[zs];
          we = zerosIndexes[ze];

          while (ws - 1 >= 0 && A[ws - 1] == 1)
            ws--;

          while (we + 1 < A.Length && A[we + 1] == 1)
            we++;

          ans = Math.Max(ans, we - ws + 1);
        }

        return ans;
      }
    }
  }
}
