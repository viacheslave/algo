namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-collisions-of-monkeys-on-a-polygon/
///    Submission: https://leetcode.com/problems/count-collisions-of-monkeys-on-a-polygon/submissions/903126553/
/// </summary>
internal class P2550
{
  public class Solution
  {
    public int MonkeyMove(int n)
    {
      // there are only 2 cases without collisions
      var ans = Power(2, n, (int)(1e9 + 7)) - 2;

      if (ans < 0)
        return ans + (int)(1e9 + 7);

      return ans;
    }

    public int Power(long x, int y, int p)
    {
      var res = 1L;

      if (x == 0)
        return 0;

      while (y > 0)
      {
        if ((y & 1) != 0)
          res = (res * x) % p;

        y >>= 1;
        x = (x * x) % p;
      }

      return (int)(res % p);
    }
  }
}
