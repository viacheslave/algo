using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3611/
  ///    https://leetcode.com/submissions/detail/447102813/?from=explore&item_id=3611
  /// </summary>
  internal class Jan21
  {
    public class Solution
    {
      public int[] MostCompetitive(int[] nums, int k)
      {
        var stack = new Stack<int>();

        for (var index = 0; index < nums.Length; index++)
        {
          var el = nums[index];
          var available = nums.Length - index;

          if (stack.Count == 0 || (stack.Count < k && stack.Peek() < el))
          {
            stack.Push(el);
            continue;
          }

          while (stack.Count > 0 && stack.Peek() > el && stack.Count + available > k)
            stack.Pop();

          if (stack.Count < k)
            stack.Push(el);
        }

        var list = stack.ToList();
        list.Reverse();

        return list.ToArray();
      }
    }
  }
}

