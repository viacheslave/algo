using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3628/
  ///    https://leetcode.com/submissions/detail/453140300/?from=explore&item_id=3628
  /// </summary>
  internal class Feb04
  {
    public class Solution
    {
      public int FindLHS(int[] nums)
      {
        var map = new SortedDictionary<int, int>();

        foreach (var num in nums)
        {
          if (!map.ContainsKey(num)) map[num] = 0;
          map[num]++;
        }

        var keys = map.Keys.ToList();
        var length = 0;

        for (var i = 1; i < keys.Count; i++)
        {
          if (keys[i] - keys[i - 1] == 1)
          {
            if (map[keys[i]] + map[keys[i - 1]] > length)
              length = map[keys[i]] + map[keys[i - 1]];
          }
        }

        return length;
      }
    }
  }
}
