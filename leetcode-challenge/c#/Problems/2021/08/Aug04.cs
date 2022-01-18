using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/613/week-1-august-1st-august-7th/3837/
  /// 
  /// </summary>
  internal class Aug04
  {
    public class Solution
    {
      public IList<IList<int>> SubsetsWithDup(int[] nums)
      {
        Array.Sort(nums);

        var filled = new List<int>();

        IList<IList<int>> res = new List<IList<int>>();

        Rec(res, filled, nums, 0);

        return res;
      }

      private void Rec(IList<IList<int>> res, List<int> filled, int[] nums, int start)
      {
        res.Add(GetRes(nums, filled));

        for (var i = start; i < nums.Length; i++)
        {
          if (filled.Contains(i))
            continue;

          filled.Add(i);

          Rec(res, filled, nums, i + 1);

          filled.Remove(i);

          var current = i;
          while ((current + 1) < nums.Length)
          {
            if (filled.Contains(current + 1))
            {
              current++;
              continue;
            }

            if (nums[current + 1] != nums[i])
            {
              break;
            }

            current++;
            i = current;
          }
        }
      }

      private List<int> GetRes(int[] nums, List<int> filled)
      {
        var cand = new List<int>();
        for (var i = 0; i < filled.Count; i++)
          cand.Add(nums[filled[i]]);

        return cand;
      }
    }
  }
}
