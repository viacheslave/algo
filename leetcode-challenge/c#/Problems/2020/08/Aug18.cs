using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/551/week-3-august-15th-august-21st/3428/
  ///    https://leetcode.com/submissions/detail/382656747/?from=/explore/challenge/card/august-leetcoding-challenge/551/week-3-august-15th-august-21st/3428/
  /// </summary>
  internal class Aug18
  {
    public class Solution
    {
      public int[] NumsSameConsecDiff(int N, int K)
      {
        var list = new List<int>();
        var res = new HashSet<int>();

        for (int i = (N == 1) ? 0 : 1; i < 10; i++)
        {
          list.Add(i);
          Traverse(res, list, K, N, i);
          list.Remove(i);
        }

        return res.ToArray();
      }

      private void Traverse(HashSet<int> res, List<int> list, int K, int N, int current)
      {
        if (list.Count == N)
        {
          res.Add(int.Parse(string.Join("", list)));
          return;
        }

        if (current - K >= 0)
        {
          list.Add(current - K);
          Traverse(res, list, K, N, current - K);
          list.RemoveAt(list.Count - 1);
        }

        if (current + K < 10)
        {
          list.Add(current + K);
          Traverse(res, list, K, N, current + K);
          list.RemoveAt(list.Count - 1);
        }
      }
    }
  }
}
