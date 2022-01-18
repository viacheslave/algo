using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3608/
  ///    https://leetcode.com/submissions/detail/447103428/?from=explore&item_id=3608
  /// </summary>
  internal class Jan18
  {
    public class Solution
    {
      public int MaxOperations(int[] nums, int k)
      {
        var map = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var visited = new HashSet<int>();
        var ans = 0;

        for (var i = 0; i < nums.Length; i++)
        {
          if (visited.Contains(nums[i]))
            continue;

          if (nums[i] + nums[i] == k)
          {
            ans += map[nums[i]] / 2;
            visited.Add(nums[i]);
            continue;
          }

          ans += Math.Min(map[nums[i]],
            map.ContainsKey(k - nums[i]) ? map[k - nums[i]] : 0);

          visited.Add(nums[i]);
          visited.Add(k - nums[i]);
        }

        return ans;
      }
    }
  }
}

