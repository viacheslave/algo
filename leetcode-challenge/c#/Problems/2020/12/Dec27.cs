using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/572/week-4-december-22nd-december-28th/3582/
  ///    https://leetcode.com/submissions/detail/435085546/?from=explore&item_id=3582
  /// </summary>
  internal class Dec27
  {
    public class Solution
    {
      public int MinJumps(int[] arr)
      {
        if (arr.Length == 1)
          return 0;

        var indexMap = arr
          .Select((x, i) => (x, i))
          .GroupBy(x => x.x)
          .ToDictionary(
            x => x.Key,
            x => x.Select(_ => _.i).OrderByDescending(_ => _).ToList());

        var seen = new HashSet<int>();
        var queue = new Queue<(int index, int steps)>();

        queue.Enqueue((0, 0));
        seen.Add(0);

        while (queue.Count > 0)
        {
          var qi = queue.Dequeue();

          var set = new HashSet<(int index, int steps)>();

          if (qi.index - 1 >= 0)
          {
            if (!seen.Contains(qi.index - 1))
            {
              set.Add((qi.index - 1, qi.steps + 1));
              seen.Add(qi.index - 1);
            }
          }

          if (qi.index + 1 < arr.Length)
          {
            if (qi.index + 1 == arr.Length - 1)
              return qi.steps + 1;

            if (!seen.Contains(qi.index + 1))
            {
              set.Add((qi.index + 1, qi.steps + 1));
              seen.Add(qi.index + 1);
            }
          }

          foreach (var i in indexMap[arr[qi.index]])
          {
            if (!seen.Contains(i))
            {
              if (i == arr.Length - 1)
                return qi.steps + 1;

              set.Add((i, qi.steps + 1));
              seen.Add(i);
            }
          }

          foreach (var item in set.OrderByDescending(_ => _))
            queue.Enqueue(item);
        }

        // should not happen
        return -1;
      }
    }
  }
}
