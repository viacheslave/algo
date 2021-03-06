namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-eaten-apples/
///    Submission: https://leetcode.com/submissions/detail/435221942/
/// </summary>
internal class P1705
{
  public class Solution
  {
    public int EatenApples(int[] apples, int[] days)
    {
      var sd = new SortedList<int, int>();
      var ans = 0;

      var day = 0;

      while (true)
      {
        // remove rotten apples
        while (sd.Count > 0 && sd.Keys[0] < day)
          sd.Remove(sd.Keys[0]);

        // add apples and their last day they can be eaten
        if (day < apples.Length && apples[day] != 0)
        {
          sd[day + days[day] - 1] = sd.ContainsKey(day + days[day] - 1)
            ? sd[day + days[day] - 1] += apples[day]
            : apples[day];
        }

        // eat apple
        // reduce the number of available apples
        if (sd.Count > 0)
        {
          ans++;

          sd[sd.Keys[0]]--;
          if (sd[sd.Keys[0]] == 0)
            sd.Remove(sd.Keys[0]);
        }

        // we exit if there's no apples left or apples will not grow
        if (sd.Count == 0 && day >= apples.Length)
          break;

        day++;
      }

      return ans;
    }
  }
}
