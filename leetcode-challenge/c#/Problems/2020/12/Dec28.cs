using System;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/572/week-4-december-22nd-december-28th/3583/
  ///    https://leetcode.com/submissions/detail/435541850/?from=explore&item_id=3583
  /// </summary>
  internal class Dec28
  {
    public class Solution
    {
      public int ReachNumber(int target)
      {
        target = Math.Abs(target);

        var steps = 0;
        var sum = 0;

        while (true)
        {
          if (sum == target)
            return steps;

          // accumulate sum until it's greater than a target
          if (sum < target)
          {
            steps++;
            sum += steps;
            continue;
          }

          var diff = sum - target;

          // if diff is even that we can reach a target by reverting one step:
          // it should be even: one move forward + the same move back
          if (diff % 2 == 0)
            return steps;

          // otherwise - accumulate until it's even
          steps++;
          sum += steps;
        }
      }
    }
  }
}
