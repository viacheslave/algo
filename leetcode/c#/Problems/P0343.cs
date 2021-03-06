namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/integer-break/
///    Submission: https://leetcode.com/submissions/detail/234918971/
/// </summary>
internal class P0343
{
  public class Solution
  {
    public int IntegerBreak(int n)
    {
      var map = new Dictionary<int, int>()
      {
        [2] = 1,
        [3] = 2,
        [4] = 4,
        [5] = 6,
        [6] = 9
      };

      if (map.ContainsKey(n))
        return map[n];

      var start = 9;

      for (var number = 7; number <= n; number++)
      {
        var power = (number - 1) / 3 - 1;
        var coeff = (number - 1) % 3 + 1;

        var inc = coeff * (int)Math.Pow(3, power);
        start += inc;

        if (number == n)
          return start;

      }

      return -1;


    }
  }
}
