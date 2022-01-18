using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3414/
  ///    https://leetcode.com/submissions/detail/376948729/?from=/explore/challenge/card/august-leetcoding-challenge/549/week-1-august-1st-august-7th/3414/
  /// </summary>
  internal class Aug06
  {
    public class Solution
    {
      public IList<int> FindDuplicates(int[] nums)
      {
        for (var i = 0; i < nums.Length; i++)
        {
          var index = (nums[i] - 1) % nums.Length;
          nums[index] += nums.Length;
        }

        var ans = new List<int>();
        for (var i = 0; i < nums.Length; i++)
        {
          if (nums[i] - nums.Length > nums.Length)
            ans.Add(i + 1);
        }

        return ans;
      }
    }
  }
}
