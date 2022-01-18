using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/diet-plan-performance/
  ///    Submission: https://leetcode.com/submissions/detail/451451072/
  ///    Amazon
  /// </summary>
  internal class P1176
  {
    public class Solution
    {
      public int DietPlanPerformance(int[] calories, int k, int lower, int upper)
      {
        var prefix = new int[calories.Length * 2 + 1];

        for (var i = 0; i < calories.Length; i++)
          prefix[i + 1] = prefix[i] + calories[i];

        var ans = 0;

        for (var i = 0; i < calories.Length - k + 1; i += 1)
        {
          var sum = prefix[k + i] - prefix[i];
          if (sum < lower)
            ans--;
          if (sum > upper)
            ans++;
        }

        return ans;
      }
    }
  }
}
