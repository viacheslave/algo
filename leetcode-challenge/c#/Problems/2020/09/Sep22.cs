using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.September.Challenge.Problems
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/557/week-4-september-22nd-september-28th/3469/
  ///    https://leetcode.com/submissions/detail/399098391/?from=/explore/challenge/card/september-leetcoding-challenge/557/week-4-september-22nd-september-28th/3469/  
  /// </summary>
  internal class Sep22
  {
    public class Solution
    {
      public IList<int> MajorityElement(int[] nums)
      {
        var map = new Dictionary<int, int>();
        foreach (var n in nums)
        {
          if (!map.ContainsKey(n)) map[n] = 0;
          map[n]++;
        }

        return map
            .Where(_ => _.Value > nums.Length / 3)
            .Select(_ => _.Key)
            .ToList();
      }
    }
  }
}
