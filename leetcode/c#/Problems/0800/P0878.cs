namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/nth-magical-number/
///    Submission: https://leetcode.com/submissions/detail/600354780/
/// </summary>
internal class P0878
{
  public class Solution
  {
    public int NthMagicalNumber(int n, int a, int b)
    {
      var mod = (int)1e9 + 7;
      var gcd = GetGcd(a, b);
      var l = 2L;
      var r = 1L * Math.Max(a, b) * n;

      // binary search
      while (true)
      {
        if (r - l < 2)
        {
          if ((l % a == 0 || l % b == 0) && GetCount(a, b, l, gcd) == n)
            return (int)(l % mod);
          return (int)(r % mod);
        }

        var m = (l + r) >> 1;
        var count = GetCount(a, b, m, gcd);

        if (count >= n)
          r = m;
        else
          l = m;
      }
    }

    private long GetCount(long a, long b, long m, int gcd)
    {
      if (a == b)
      {
        return m / a;
      }

      if (a % b == 0 || b % a == 0)
      {
        var min = Math.Min(a, b);
        return m / min;
      }

      var a_count = m / a;
      var b_count = m / b;

      var c_count = m / (a * b / gcd);

      return a_count + b_count - c_count;
    }

    private int GetGcd(int a, int b)
    {
      if (a == b)
        return a;

      return a > b
        ? GetGcd(a - b, b)
        : GetGcd(a, b - a);
    }
  }

}
