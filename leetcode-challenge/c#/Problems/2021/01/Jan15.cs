using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3605/
  ///    https://leetcode.com/submissions/detail/449284142/?from=explore&item_id=3605
  /// </summary>
  internal class Jan15
  {
    public class Solution
    {
      public int GetMaximumGenerated(int n)
      {
        if (n == 0)
          return 0;

        if (n == 1)
          return 1;

        var arr = new int[n + 1];
        arr[0] = 0;
        arr[1] = 1;

        for (var i = 2; i < n + 1; i++)
        {
          if (i % 2 == 0)
            arr[i] = arr[i / 2];
          else
            arr[i] = arr[(i - 1) / 2] + arr[(i - 1) / 2 + 1];
        }

        return arr.Max();
      }
    }
  }
}

