namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/ways-to-express-an-integer-as-sum-of-powers/
///    Submission: https://leetcode.com/problems/ways-to-express-an-integer-as-sum-of-powers/submissions/1030573626/
/// </summary>
internal class P2787
{
  public class Solution
  {
    public int NumberOfWays(int n, int x)
    {
      // calculate max base
      var maxBase = 1;
      while (Math.Pow(maxBase + 1, x) <= n)
        maxBase++;

      var dp = new int[n + 1, maxBase + 1];

      for (int s = 1; s <= n; s++)
      {
        dp[s, 1] = s == 1 ? 1 : 0;
      }

      // bottom-up DP

      // calculate for every pair (b, s)
      for (int b = 2; b <= maxBase; b++)
      {
        for (int s = 1; s <= n; s++)
        {
          var last = (int)Math.Pow(b, x);
          var value = 0;

          // sum all lower bases
          for (int lb = b; lb >= 1; lb--)
          {
            if (lb == b)
            {
              if (last == s)
              {
                value++;
                value %= (int)1e9 + 7;
              }
              continue;
            }

            if (s - last <= 0)
              continue;

            value += dp[s - last, lb];
            value %= (int)1e9 + 7;
          }

          dp[s, b] = value;
        }
      }

      var ans = 0;
      for (var b = 1; b <= maxBase; b++)
      {
        ans += dp[n, b];
        ans %= (int)1e9 + 7;
      }

      return ans;
    }
  }

}
