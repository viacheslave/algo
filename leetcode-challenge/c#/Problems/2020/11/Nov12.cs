using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3528/
  ///    https://leetcode.com/submissions/detail/419507293/?from=/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3528/
  /// </summary>
  internal class Nov12
  {
    public class Solution
    {
      public IList<IList<int>> PermuteUnique(int[] nums)
      {
        Array.Sort(nums);

        var filled = new List<int>();

        IList<IList<int>> res = new List<IList<int>>();

        Rec(res, filled, nums, nums.Length);

        return res;
      }

      private void Rec(IList<IList<int>> res, List<int> filled, int[] nums, int left)
      {
        if (left == 0)
        {
          var cand = new List<int>();
          for (var i = 0; i < filled.Count; i++)
            cand.Add(nums[filled[i]]);

          res.Add(cand);
          return;
        }

        for (var i = 0; i < nums.Length; i++)
        {
          if (filled.Contains(i))
            continue;

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

          filled.Add(i);

          Rec(res, filled, nums, left - 1);

          filled.Remove(i);
        }
      }
    }
  }
}
