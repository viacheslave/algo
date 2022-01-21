namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/gas-station/
///    Submission: https://leetcode.com/submissions/detail/624657144/
/// </summary>
internal class P0134_2
{
  public class Solution
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
