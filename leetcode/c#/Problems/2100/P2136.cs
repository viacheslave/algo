namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/earliest-possible-day-of-full-bloom/
///    Submission: https://leetcode.com/submissions/detail/616148970/
/// </summary>
internal class P2136
{
  public class Solution
  {
    public int EarliestFullBloom(int[] plantTime, int[] growTime)
    {
      var items = new List<(int Seed, int Grow)>();

      for (int i = 0; i < plantTime.Length; i++)
      {
        items.Add((plantTime[i], growTime[i]));
      }

      items = items.OrderByDescending(x => x.Grow).ToList();

      var ans = int.MinValue;
      var passed = 0;

      for (int i = 0; i < plantTime.Length; i++)
      {
        var value = passed + items[i].Seed + items[i].Grow;
        ans = Math.Max(ans, value);

        passed += items[i].Seed;
      }

      return ans;
    }
  }
}
