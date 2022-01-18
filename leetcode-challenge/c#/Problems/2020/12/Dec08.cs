using System.Collections.Generic;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3559/
  ///    https://leetcode.com/submissions/detail/428498279/?from=explore&item_id=3559
  /// </summary>
  internal class Dec08
  {
    public class Solution
    {
      public int NumPairsDivisibleBy60(int[] time)
      {
        var d = new Dictionary<int, int>();

        for (var i = 0; i < time.Length; i++)
        {
          if (!d.ContainsKey(time[i] % 60))
            d[time[i] % 60] = 0;
          d[time[i] % 60]++;
        }


        var count = 0;
        if (d.ContainsKey(0))
          count += (d[0] * (d[0] - 1)) / 2;
        if (d.ContainsKey(30))
          count += ((d[30]) * ((d[30]) - 1)) / 2;

        for (var i = 1; i <= 29; i++)
        {
          var f1 = 0;
          var f2 = 0;
          if (d.ContainsKey(i))
            f1 = d[i];
          if (d.ContainsKey(60 - i))
            f2 = d[60 - i];

          count += f1 * f2;
        }

        return count;
      }
    }
  }
}
