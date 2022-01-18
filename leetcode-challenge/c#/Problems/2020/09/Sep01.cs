using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/554/week-1-september-1st-september-7th/3445/
  ///
  /// </summary>
  internal class Sep01
  {
    public class Solution
    {
      public string LargestTimeFromDigits(int[] A)
      {
        var max = -1;
        var res = "";

        for (var a1 = 0; a1 < 4; a1++)
        {
          for (var a2 = 0; a2 < 4; a2++)
          {
            if (a2 == a1) continue;

            for (var a3 = 0; a3 < 4; a3++)
            {
              if (a3 == a2 || a3 == a1) continue;

              for (var a4 = 0; a4 < 4; a4++)
              {
                if (a4 == a3 || a4 == a2 || a4 == a1) continue;

                var hour = A[a1] * 10 + A[a2];
                var min = A[a3] * 10 + A[a4];

                if (hour > 23 || min > 59)
                  continue;

                var value = A[a1] * 1000 + A[a2] * 100 + A[a3] * 10 + A[a4];
                if (max < value)
                {
                  max = value;
                  res = $"{A[a1]}{A[a2]}:{A[a3]}{A[a4]}";
                }
              }
            }
          }
        }

        return res;
      }
    }
  }
}
