namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-distinct-roll-sequences/
///    Submission: https://leetcode.com/submissions/detail/737216291/
/// </summary>
internal class P2318
{
  public class Solution
  {
    public int DistinctSequences(int n)
    {
      if (n == 1)
      {
        return 6;
      }

      // DP
      // GCP can be hardcoded
      // Gap of 2 contributed as: we add: iteration - 2, iteration - 4..
      // and subtract: iteration - 1, iteration - 3 etc.

      var gdpNotOne = new HashSet<(int, int)>
    {
      (2, 4),
      (2, 6),
      (3, 6),
      (4, 6),
      (4, 2),
      (6, 2),
      (6, 3),
      (6, 4),
    };

      var ans = 0;
      var mod = (int)1e9 + 7;

      var even = new int[6];
      var odd = new int[6];
      var next = new int[6];

      Array.Fill(even, 1);

      for (var iteration = 1; iteration < n; iteration++)
      {
        Array.Clear(next);

        for (var i = 0; i < 6; i++)
        {
          for (var k = 0; k < 6; k++)
          {
            if (i == k || gdpNotOne.Contains((i + 1, k + 1)))
              continue;

            if (iteration % 2 == 0)
            {
              next[i] += odd[k];
              next[i] %= mod;

              next[i] -= even[i];
              if (next[i] < 0) next[i] += mod;
            }
            else
            {
              next[i] += even[k];
              next[i] %= mod;

              next[i] -= odd[i];
              if (next[i] < 0) next[i] += mod;
            }
          }

          if (iteration % 2 == 0)
          {
            even[i] += next[i];
            even[i] %= mod;
          }
          else
          {
            odd[i] += next[i];
            odd[i] %= mod;
          }
        }
      }

      foreach (var a in next)
      {
        ans += a;
        ans %= mod;
      }

      return ans;
    }
  }
}
