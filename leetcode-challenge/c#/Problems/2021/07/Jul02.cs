using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/july-leetcoding-challenge-2021/608/week-1-july-1st-july-7th/3800/
  /// 
  /// </summary>
  internal class Jul02
  {
    public class Solution
    {
      public IList<int> FindClosestElements(int[] arr, int k, int x)
      {
        if (x < arr[0])
          return arr.Take(k).ToList();

        if (x > arr[arr.Length - 1])
          return arr.Reverse().Take(k).Reverse().ToList();

        int li = 0,
            ri = arr.Length - 1;

        for (int i = 0; i < arr.Length; i++)
        {
          if (arr[i] == x)
          {
            li = i;
            ri = i;
            break;
          }

          if (arr[i] < x && x < arr[i + 1])
          {
            li = i;
            ri = i + 1;
            break;
          }
        }

        var values = new List<int>();

        while (k != 0)
        {
          if (li == ri)
          {
            values.Add(arr[li]);
            li--; ri++;
            k--;
            continue;
          }

          if (li >= 0 && ri < arr.Length)
          {
            var dleft = Math.Abs(arr[li] - x);
            var dright = Math.Abs(arr[ri] - x);

            if (dleft <= dright)
            {
              values.Add(arr[li]);
              li--;
            }
            else
            {
              values.Add(arr[ri]);
              ri++;
            }

            k--;
            continue;
          }

          if (ri >= arr.Length)
          {
            values.Add(arr[li]);
            li--;
            k--;
            continue;
          }

          if (li < 0)
          {
            values.Add(arr[ri]);
            ri++;
            k--;
            continue;
          }
        }

        values.Sort();
        return values;
      }
    }
  }
}
