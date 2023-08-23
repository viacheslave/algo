namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-robots-within-budget/
///    Submission: https://leetcode.com/submissions/detail/797140755/
/// </summary>
internal class P2398
{
  public class Solution
  {
    public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget)
    {
      var n = chargeTimes.Length;
      var prefixSums = new long[n + 1];

      for (int i = 0; i < n; i++)
      {
        prefixSums[i + 1] = prefixSums[i] + runningCosts[i];
      }

      // sliding window
      var ans = 0;

      var from = 0;
      var to = 0;
      var map = new SortedList<int, int>() { [chargeTimes[0]] = 1 };

      while (to < n)
      {
        var fits = Fits2(from, to, prefixSums, map, budget);

        while (!fits && from <= to)
        {
          if (from == to)
            break;

          // shift
          map[chargeTimes[from]]--;
          if (map[chargeTimes[from]] == 0)
            map.Remove(chargeTimes[from]);

          from++;

          fits = Fits2(from, to, prefixSums, map, budget);
        }

        if (fits)
        {
          ans = Math.Max(ans, to - from + 1);
        }
        else if (from == to)
        {
          map[chargeTimes[from]]--;
          if (map[chargeTimes[from]] == 0)
            map.Remove(chargeTimes[from]);

          from++;
        }

        to++;
        if (to == n)
          break;

        // shift
        if (!map.ContainsKey(chargeTimes[to]))
          map[chargeTimes[to]] = 0;
        map[chargeTimes[to]]++;
      }

      return ans;
    }

    private bool Fits2(int from, int to, long[] prefixSums, SortedList<int, int> map, long budget)
    {
      var length = to - from + 1;
      var maxKey = map.Keys[^1];
      var value = maxKey + length * (prefixSums[to + 1] - prefixSums[from]);

      return value <= budget;
    }
  }

}
