using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/568/week-5-november-29th-november-30th/3548/
  ///    https://leetcode.com/submissions/detail/425300027/?from=/explore/challenge/card/november-leetcoding-challenge/568/week-5-november-29th-november-30th/3548/
  /// </summary>
  internal class Nov29
  {
    public class Solution
    {
      public bool CanReach(int[] arr, int start)
      {
        var q = new Queue<int>();
        q.Enqueue(start);

        var set = new HashSet<int>();

        while (q.Count > 0)
        {
          var index = q.Dequeue();
          if (arr[index] == 0)
            return true;

          if (set.Contains(index))
            continue;

          set.Add(index);

          var left = index - arr[index];
          var right = index + arr[index];

          if (left >= 0)
            q.Enqueue(left);
          if (right < arr.Length)
            q.Enqueue(right);
        }

        return false;
      }
    }
  }
}
