using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3591/
  ///    https://leetcode.com/submissions/detail/437924042/?from=explore&item_id=3591
  /// </summary>
  internal class Jan03
  {
    public class Solution
    {
      private int _ans = 0;

      public int CountArrangement(int N)
      {
        var set = new SortedSet<int>(Enumerable.Range(1, N));

        var list = new List<int>(N);

        Count(set, list, 0);

        return _ans;
      }

      private void Count(SortedSet<int> set, List<int> list, int index)
      {
        if (set.Count == 0)
        {
          _ans++;
          return;
        }

        var pos = index + 1;

        foreach (var el in set.ToArray())
        {
          if (el % pos == 0 || pos % el == 0)
          {
            list.Add(el);
            set.Remove(el);

            Count(set, list, index + 1);

            set.Add(el);
            list.RemoveAt(list.Count - 1);
          }
        }
      }
    }
  }
}
