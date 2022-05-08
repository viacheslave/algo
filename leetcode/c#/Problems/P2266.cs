namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-number-of-texts/
///    Submission: https://leetcode.com/submissions/detail/695567638/
/// </summary>
internal class P2266
{
  public class Solution
  {
    public int CountTexts(string pressedKeys)
    {
      if (pressedKeys.Length == 1)
        return 1;

      var borders = new List<int>();
      for (var i = 1; i < pressedKeys.Length; i++)
      {
        if (pressedKeys[i] != pressedKeys[i - 1])
          borders.Add(i - 1);
      }

      borders.Add(pressedKeys.Length - 1);

      // intervals
      var intervals = new List<(int, int)>();
      for (var i = 0; i < borders.Count; i++)
      {
        var border = borders[i];
        var digit = int.Parse(pressedKeys[border].ToString());
        var count = i == 0 ? (border + 1) : (border - borders[i - 1]);

        intervals.Add((digit, count));
      }

      var map = new List<int>();

      foreach (var interval in intervals)
      {
        var dp = new int[interval.Item2 + 1];
        dp[0] = 1;

        for (var i = 1; i < dp.Length; i++)
        {
          for (var j = 1; j <= (interval.Item1 == 7 || interval.Item1 == 9 ? 4 : 3); j++)
          {
            if (i - j >= 0)
            {
              dp[i] += dp[i - j];
              dp[i] %= 1_000_000_007;
            }
          }
        }

        map.Add(dp[interval.Item2]);
      }

      var ans = 1;

      foreach (var mapItem in map)
        ans = MultMod(ans, mapItem, 1_000_000_007);

      return ans;
    }

    private static int MultMod(int a, int b, int mod)
    {
      var res = 0;
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
