using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/570/week-2-december-8th-december-14th/3565/
  ///    https://leetcode.com/submissions/detail/430510140/?from=explore&item_id=3565
  /// </summary>
  internal class Dec14
  {
    public class Solution
    {
      public IList<IList<string>> Partition(string s)
      {
        var ans = new List<IList<string>>();
        var current = new List<string>();

        Partition(0, s, current, ans);

        return ans;
      }

      private void Partition(int start, string s, IList<string> current, List<IList<string>> ans)
      {
        if (start == s.Length)
        {
          ans.Add(new List<string>(current));
          return;
        }

        for (var end = start; end < s.Length; end++)
        {
          if (Palindrome(s, start, end))
          {
            current.Add(s.Substring(start, end - start + 1));

            Partition(end + 1, s, current, ans);

            current.RemoveAt(current.Count - 1);
          }
        }
      }

      private bool Palindrome(string s, int start, int end)
      {
        for (var i = 0; i < (end - start + 1) / 2; i++)
          if (s[start + i] != s[end - i])
            return false;

        return true;
      }
    }
  }
}
