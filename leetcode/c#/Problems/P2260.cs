namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-consecutive-cards-to-pick-up/
///    Submission: https://leetcode.com/submissions/detail/691714403/
/// </summary>
internal class P2260
{
  public class Solution
  {
    public int MinimumCardPickup(int[] cards)
    {
      var ind = cards
        .Select((c, i) => (c, i))
        .GroupBy(x => x.c)
        .ToDictionary(x => x.Key, x => x.Select(f => f.i).ToList());

      var ans = int.MaxValue;

      foreach (var c in ind)
      {
        var list = c.Value;
        if (list.Count == 1)
        {
          continue;
        }

        for (var j = 1; j < list.Count; j++)
          ans = Math.Min(ans, list[j] - list[j - 1] + 1);
      }

      if (ans == int.MaxValue)
        return -1;

      return ans;
    }
  }
}
