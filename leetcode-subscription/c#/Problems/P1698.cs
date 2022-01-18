using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-distinct-substrings-in-a-string/
  ///    Submission: https://leetcode.com/submissions/detail/461710938/
  ///    Intuit, Dunzo
  /// </summary>
  internal class P1698
  {
    public class Solution
    {
      public int CountDistinct(string s)
      {
        var rolling = new RollingHash(s);
        var seen = new HashSet<long>();
        var ans = 0;

        for (var i = 0; i < s.Length; i++)
        {
          for (var j = i; j < s.Length; j++)
          {
            var hash = rolling.Hash(i, j);
            if (seen.Contains(hash))
              continue;

            seen.Add(hash);
            ans++;
          }
        }

        return ans;
      }

      public class RollingHash
      {
        long[] p;
        long[] h;

        const long A = 3176161685720312321;
        const long B = 78556651776524353;

        public RollingHash(string text)
        {
          h = new long[text.Length];
          p = new long[text.Length];

          h[0] = text[0] % B;
          p[0] = 1;

          for (var i = 1; i < text.Length; i++)
          {
            h[i] = (Mod(h[i - 1], A, B) + text[i]) % B;
            p[i] = (Mod(p[i - 1], A, B)) % B;
          }
        }

        public long Hash(int from, int to)
        {
          return Hash(h, p, from, to, B);
        }

        private long Hash(long[] h, long[] p, long a, long b, long B)
        {
          if (a == 0)
            return h[b];

          return ((h[b] + B) - Mod(h[a - 1], p[b - a + 1], B)) % B;
        }

        private long Mod(long a, long b, long mod)
        {
          var res = 0L;
          a %= mod;

          while (b > 0)
          {
            if ((b & 1) > 0)
              res = (res + a) % mod;

            a = (2 * a) % mod;
            b >>= 1;
          }

          return res;
        }
      }
    }
  }
}
