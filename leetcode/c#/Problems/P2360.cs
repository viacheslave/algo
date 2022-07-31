namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-cycle-in-a-graph/
///    Submission: https://leetcode.com/submissions/detail/761586607/
/// </summary>
internal class P2360
{
  public class Solution
  {
    public int LongestCycle(int[] edges)
    {
      // the idea is to move along the connections and save the visited
      // if current is in visited - new cycle is detected
      // if an existing cycle is met - stop

      var longest = new int[edges.Length];

      Array.Fill(longest, -1);

      for (int i = 0; i < edges.Length; i++)
      {
        Calculate(i, edges, longest);
      }

      var max = longest.Max();
      return max == 0 ? -1 : max;
    }

    private void Calculate(int e, int[] edges, int[] longest)
    {
      var set = new Dictionary<int, int>();

      var current = e;
      var index = 0;

      while (current != -1)
      {
        if (longest[current] != -1)
        {
          // met another cycle
          // all set is outside the cycle
          foreach (var item in set)
          {
            longest[item.Key] = 0;
          }
          return;
        }

        if (set.ContainsKey(current))
        {
          // cycle found
          // split item inside and outside the cycle 
          var cycle = index - set[current];

          foreach (var item in set)
          {
            if (set[current] <= item.Value)
              longest[item.Key] = cycle;
            else
              longest[item.Key] = 0;
          }

          return;
        }

        set[current] = index++;
        current = edges[current];
      }

      // no cycle
      foreach (var key in set.Keys)
      {
        longest[key] = 0;
      }
    }
  }

}
