namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-ways-to-divide-a-long-corridor/
///    Submission: https://leetcode.com/submissions/detail/625341622/
/// </summary>
/// <remarks>
///   Create groups of two seats.
///   Calculate who many plans are between the groups.
///   Combine.
/// </remarks>
internal class P2147
{
  public class Solution
  {
    public int NumberOfWays(string corridor)
    {
      var count = corridor.Count(c => c == 'S');
      if (count == 0)
        return 0;

      if (count % 2 != 0)
        return 0;

      var seats = new List<(int, int)>();

      var left = -1;

      for (var i = 0; i < corridor.Length; i++)
      {
        if (corridor[i] == 'S' && left == -1)
        {
          left = i;
          continue;
        }

        if (corridor[i] == 'S' && left != -1)
        {
          seats.Add((left, i));

          left = -1;
          continue;
        }
      }

      if (seats.Count == 1)
        return 1;

      var mod = (int)1e9 + 7;

      var diffs = new List<int>();
      for (int i = 1; i < seats.Count; i++)
      {
        diffs.Add(seats[i].Item1 - seats[i - 1].Item2);
      }

      if (diffs.Count == 1)
        return diffs[0];

      var ans = 1L;
      ans *= diffs[0];

      for (var i = 1; i < diffs.Count; i++)
      {
        ans = (ans * (diffs[i])) % mod;
      }

      return (int)(ans % mod);
    }
  }
}
