using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/strobogrammatic-number-ii/
  ///    Submission: https://leetcode.com/submissions/detail/450769856/
  ///    Facebook, Google
  /// </summary>
  internal class P0247
  {
    public class Solution
    {
      public IList<string> FindStrobogrammatic(int n)
      {
        var arr = new char[n];
        var mid = (n - 1) / 2;

        var ans = new List<string>();

        Rec(ans, arr, 0, n, mid);

        return ans;
      }

      private void Rec(List<string> ans, char[] arr, int index, int len, int mid)
      {
        var ch = new char[] { '0', '1', '6', '8', '9' };
        var st = new char[] { '0', '1', '9', '8', '6' };

        for (var i = 0; i < ch.Length; i++)
        {
          arr[index] = ch[i];
          arr[len - 1 - index] = st[i];

          if (index != mid)
          {
            Rec(ans, arr, index + 1, len, mid);
          }
          else
          {
            if (arr[0] == '0' && len > 1)
              continue;

            if (index * 2 + 1 == len && (ch[i] == '6' || ch[i] == '9'))
              continue;

            ans.Add(new string(arr));
          }
        }
      }
    }
  }
}
