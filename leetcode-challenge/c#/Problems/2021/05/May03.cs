using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/may-leetcoding-challenge-2021/598/week-1-may-1st-may-7th/3730/
  /// 
  /// </summary>
  internal class May03
  {
    public class Solution
    {
      public int[] RunningSum(int[] nums)
      {
        var ans = new int[nums.Length];

        var running = 0;

        for (var i = 0; i < nums.Length; i++)
        {
          running += nums[i];
          ans[i] = running;
        }

        return ans;
      }
    }
  }
}
