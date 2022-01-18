using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/588/week-1-march-1st-march-7th/3659/
  /// 
  /// </summary>
  internal class Mar03
  {
    public class Solution
    {
      public int MissingNumber(int[] nums)
      {
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
          sum += nums[i];

        var expected = (nums.Length + 1) * (nums.Length) / 2;

        return expected - sum;
      }
    }
  }
}
