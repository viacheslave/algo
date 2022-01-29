namespace LeetCode.Naive.Problems;

internal class P0134
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/gas-station/
  ///    Submission: https://leetcode.com/submissions/detail/245910052/
  /// </summary>
  public class Solution
  {
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
      if (gas.Sum() < cost.Sum())
        return -1;

      for (var start = 0; start < gas.Length; start++)
      {
        var counter = 0;
        var currentPos = start + counter;
        var accum = 0;
        var possible = true;

        while (counter < gas.Length)
        {
          accum += gas[currentPos % gas.Length] - cost[currentPos % gas.Length];
          if (accum < 0)
          {
            possible = false;
            break;
          }

          counter++;
          currentPos = start + counter;
        }

        if (possible)
          return start;
      }

      return -1;
    }
  }

  /// <summary>
  ///    Problem: https://leetcode.com/problems/gas-station/
  ///    Submission: https://leetcode.com/submissions/detail/624657144/
  /// </summary>
  public class Solution2
  {
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
      if (gas.Sum() < cost.Sum())
        return -1;

      var n = gas.Length;
      var balance = new int[n];

      for (var i = 0; i < n; i++)
        balance[i] = gas[i] - cost[i];

      var indices = balance.Select((e, i) => (e, i)).OrderByDescending(x => x.e)
        .ToArray();

      foreach (var ind in indices)
      {
        var i = ind.i;

        var sum = 0;
        for (int j = 0; j < n; j++)
        {
          sum += balance[(i + j) % n];
          if (sum < 0)
            break;
        }

        if (sum >= 0)
          return i;
      }

      return -1;
    }
  }
}
