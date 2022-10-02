using System.Numerics;

namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/
///    Submission: https://leetcode.com/submissions/detail/258946680/
/// </summary>
internal class P1155
{
  public class Solution
  {
    public int NumRollsToTarget(int d, int f, int target)
    {
      var dp = new Dictionary<(int, int), int>();

      return Get(dp, d, f, target);
    }

    private int Get(Dictionary<(int, int), int> dp, int d, int f, int target)
    {
      if (target == 0)
        return 0;

      if (d == 1)
      {
        int val = f >= target ? 1 : 0;
        dp[(d, target)] = val;
        return val;
      }

      BigInteger count = 0;
      for (int i = 1; i <= f; i++)
      {
        if (i > target)
          break;

        int val;
        if (dp.ContainsKey((d - 1, target - i)))
          val = dp[(d - 1, target - i)];
        else
          val = Get(dp, d - 1, f, target - i);

        count += val;
      }

      dp[(d, target)] = (int)(count % 1_000_000_007);
      return dp[(d, target)];
    }
  }
}
/// <summary>
///    Problem: https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/
///    Submission: https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/submissions/813405657/
/// </summary>
internal class P1155_2
{
  public class Solution
  {
    public int NumRollsToTarget(int n, int k, int target)
    {
      // top-down DP

      var memo = new int[n + 1, target + 1];

      for (int i = 0; i <= n; i++)
        for (int j = 0; j <= target; j++)
          memo[i, j] = -1;

      return Calculate(memo, n, k, target);
    }

    private int Calculate(int[,] memo, int n, int k, int target)
    {
      if (memo[n, target] != -1)
        return memo[n, target];

      if (n == 1)
      {
        memo[n, target] = 1 <= target && target <= k ? 1 : 0;
        return memo[n, target];
      }

      var sum = 0;
      for (int roll = 1; roll <= k; roll++)
      {
        if (target - roll >= 1)
        {
          var res = Calculate(memo, n - 1, k, target - roll);
          sum += res;
          sum %= 1_000_000_007;
        }
      }

      memo[n, target] = sum;
      return sum;
    }
  }
}
