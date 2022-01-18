using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/563/week-5-october-29th-october-31st/3513/
  ///    https://leetcode.com/submissions/detail/414864021/?from=/explore/challenge/card/october-leetcoding-challenge/563/week-5-october-29th-october-31st/3513/
  /// </summary>
  internal class Oct30
  {
    public class Solution
    {
      public int FindNumberOfLIS(int[] nums)
      {
        if (nums.Length == 0)
          return 0;

        var lis = new Dictionary<int, (int length, int count)>();

        for (int i = 0; i < nums.Length; i++)
        {
          var ithlength = 0;
          var ithcount = 0;

          for (int j = 0; j < i; j++)
          {
            if (nums[j] < nums[i])
            {
              if (lis[j].length + 1 == ithlength)
              {
                ithcount += lis[j].count;
              }

              if (lis[j].length + 1 > ithlength)
              {
                ithlength = lis[j].length + 1;
                ithcount = lis[j].count;
              }
            }
          }

          if (ithlength == 0)
          {
            ithlength = 1;
            ithcount = 1;
          }

          lis[i] = (ithlength, ithcount);
        }

        var maxLength = lis.Values.Max(_ => _.length);
        return lis.Where(_ => _.Value.length == maxLength).Sum(_ => _.Value.count);
      }
    }
  }
}
