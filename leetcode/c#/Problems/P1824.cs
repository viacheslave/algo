namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-sideway-jumps/
///    Submission: https://leetcode.com/submissions/detail/586045861/
/// </summary>
internal class P1824
{
  public class Solution
  {
    public int MinSideJumps(int[] obstacles)
    {
      var dp = new int[obstacles.Length, 3];

      dp[0, 0] = 1;
      dp[0, 1] = 0;
      dp[0, 2] = 1;

      for (int i = 0; i < obstacles.Length - 1; i++)
      {
        dp[i + 1, 0] = int.MaxValue;
        dp[i + 1, 1] = int.MaxValue;
        dp[i + 1, 2] = int.MaxValue;

        var o = obstacles[i] - 1;
        var on = obstacles[i + 1] - 1;

        var value = int.MaxValue;
        if (o != 0)
        {
          if (on != 0)
            dp[i + 1, 0] = Math.Min(dp[i + 1, 0], dp[i, 0]);
          if (on != 1 && (on != 0 || o != 1))
            dp[i + 1, 1] = Math.Min(dp[i + 1, 1], dp[i, 0] + 1);
          if (on != 2 && (on != 0 || o != 2))
            dp[i + 1, 2] = Math.Min(dp[i + 1, 2], dp[i, 0] + 1);
        }

        if (o != 1)
        {
          if (on != 1)
            dp[i + 1, 1] = Math.Min(dp[i + 1, 1], dp[i, 1]);
          if (on != 0 && (on != 1 || o != 0))
            dp[i + 1, 0] = Math.Min(dp[i + 1, 0], dp[i, 1] + 1);
          if (on != 2 && (on != 1 || o != 2))
            dp[i + 1, 2] = Math.Min(dp[i + 1, 2], dp[i, 1] + 1);
        }

        if (o != 2)
        {
          if (on != 2)
            dp[i + 1, 2] = Math.Min(dp[i + 1, 2], dp[i, 2]);
          if (on != 1 && (on != 2 || o != 1))
            dp[i + 1, 1] = Math.Min(dp[i + 1, 1], dp[i, 2] + 1);
          if (on != 0 && (on != 2 || o != 0))
            dp[i + 1, 0] = Math.Min(dp[i + 1, 0], dp[i, 2] + 1);
        }
      }

      return Math.Min(dp[obstacles.Length - 1, 0],
          Math.Min(dp[obstacles.Length - 1, 1],
            dp[obstacles.Length - 1, 2]));
    }
  }
}
