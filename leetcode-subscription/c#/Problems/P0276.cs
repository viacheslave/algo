using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/paint-fence/
  ///    Submission: https://leetcode.com/submissions/detail/451644523/
  ///    JPMorgan  
  /// </summary>
  internal class P0276
  {
    public class Solution
    {
      public int NumWays(int n, int k)
      {
        if (n == 0 || k == 0)
          return 0;

        if (k == 1)
          if (n <= 2)
            return 1;
          else
            return 0;

        if (n == 2)
          return k * k;

        var dp = new int[n, k, 2];

        for (var i = 0; i < k; i++)
          dp[0, i, 0] = 1;

        for (var p = 1; p < n; p++)
          for (var c = 0; c < k; c++)
            for (var cp = 0; cp < k; cp++)
              for (var s = 0; s < 2; s++)
                if (s == 0 || c != cp)
                  dp[p, c, c == cp ? 1 : 0] += dp[p - 1, cp, s];

        var ans = 0;

        for (var i = 0; i < k; i++)
          for (var s = 0; s < 2; s++)
            ans += dp[n - 1, i, s];

        return ans;
      }
    }
  }
}
