using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/608/week-1-july-1st-july-7th/3804/
  /// 
  /// </summary>
  internal class Jul06
  {
    public class Solution
    {
      public int MinSetSize(int[] arr)
      {
        var counts = arr.GroupBy(a => a).Select(a => a.Count()).OrderByDescending(a => a).ToList();

        var total = 0;
        var ans = 0;

        for (int i = 0; i < counts.Count; i++)
        {
          total += counts[i];
          ans++;

          if (total >= arr.Length / 2)
            break;
        }

        return ans;
      }
    }
  }
}
