namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-cost-to-set-cooking-time/
///    Submission: https://leetcode.com/submissions/detail/635035412/
/// </summary>
internal class P2162
{
  public class Solution
  {
    public int MinCostSetTime(int startAt, int moveCost, int pushCost, int targetSeconds)
    {
      var variants = new List<(int, int)>();

      var maxMinutes = 6039 / 60;

      for (var i = 0; i <= maxMinutes; i++)
      {
        var minutes = i;
        var seconds = targetSeconds - minutes * 60;

        if (minutes < 100 && seconds >= 0 && seconds < 100)
        {
          variants.Add((minutes, seconds));
        }
      }

      var ans = int.MaxValue;

      foreach (var v in variants)
      {
        var cost = 0;
        var normalized = int.Parse($"{v.Item1:D2}{v.Item2:D2}").ToString();

        var current = startAt;

        for (var i = 0; i < normalized.Length; i++)
        {
          var digit = int.Parse(normalized[i].ToString());

          if (digit != current)
          {
            cost += moveCost;
          }

          cost += pushCost;
          current = digit;
        }

        ans = Math.Min(ans, cost);
      }

      return ans;
    }
  }

}
