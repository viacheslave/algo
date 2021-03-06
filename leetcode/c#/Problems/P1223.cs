namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/dice-roll-simulation/
///    Submission: https://leetcode.com/submissions/detail/422337052/
/// </summary>
internal class P1223
{
  public class Solution
  {
    public int DieSimulator(int n, int[] rollMax)
    {
      var dp = new Dictionary<(int die, int seen), int>();

      for (var die = 0; die < 6; die++)
        dp[(die, 1)] = 1;

      for (var i = 1; i < n; i++)
      {
        var state = new Dictionary<(int, int), int>();

        foreach (var key in dp.Keys)
        {
          for (var die = 0; die < 6; die++)
          {
            var nextkey = (key.die, key.seen);

            if (key.die == die)
            {
              if (key.seen + 1 <= rollMax[die])
                Add(dp, state, key, (die, key.seen + 1));
            }
            else
            {
              Add(dp, state, key, (die, 1));
            }
          }
        }

        dp = state;
      }

      var ans = 0;
      foreach (var value in dp.Values)
      {
        ans += value;
        ans %= (int)1e9 + 7;
      }

      return ans;

      static void Add(
        Dictionary<(int die, int seen), int> dp,
        Dictionary<(int, int), int> state,
        (int die, int seen) key,
        (int die, int seen) nextkey)
      {
        if (!state.ContainsKey(nextkey))
          state[nextkey] = 0;

        state[nextkey] += dp[key];
        state[nextkey] %= (int)1e9 + 7;
      }
    }
  }
}
