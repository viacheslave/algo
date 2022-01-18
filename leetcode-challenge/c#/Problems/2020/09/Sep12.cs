using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3457/
  ///    https://leetcode.com/submissions/detail/394508105/?from=/explore/challenge/card/september-leetcoding-challenge/555/week-2-september-8th-september-14th/3457/
  /// </summary>
  internal class Sep12
  {
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
      var cand = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      var arrIndex = new List<int>(cand.Count);
      var res = new List<IList<int>>();

      Comb(cand, arrIndex, res, k, n, 0);

      return res;
    }

    private void Comb(List<int> cand, List<int> arrIndex, List<IList<int>> res, int l, int target, int iteration)
    {
      for (var i = iteration; i < cand.Count; i++)
      {
        arrIndex.Add(cand[i]);

        if (arrIndex.Count < l)
        {
          Comb(cand, arrIndex, res, l, target, i + 1);
        }
        else
        {
          var sum = arrIndex.Sum();

          if (sum == target)
          {
            res.Add(new List<int>(arrIndex));
            arrIndex.RemoveAt(arrIndex.Count - 1);
            break;
          }

          if (sum > target)
          {
            arrIndex.RemoveAt(arrIndex.Count - 1);
            break;
          }
        }

        arrIndex.RemoveAt(arrIndex.Count - 1);
      }
    }
  }
}
