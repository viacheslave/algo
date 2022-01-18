using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/
  ///    Submission: https://leetcode.com/submissions/detail/455530443/
  ///    Microsoft, Facebook
  /// </summary>
  internal class P0159
  {
    public class Solution
    {
      public int LengthOfLongestSubstringTwoDistinct(string s)
      {
        if (s.Length <= 2)
          return s.Length;

        var ans = 2;

        var from = 0;
        var to = 0;

        var set = new Dictionary<char, int>();
        Add(set, s[0]);

        // two pointers
        while (true)
        {
          if (to == s.Length - 1)
            break;

          while (to < s.Length - 1)
          {
            to++;
            Add(set, s[to]);

            if (set.Count > 2)
              break;

            ans = Math.Max(ans, to - from + 1);
          }

          while (set.Count > 2)
          {
            from++;
            Remove(set, s[from - 1]);
          }
        }

        return ans;
      }

      private void Add(Dictionary<char, int> set, char v)
      {
        if (!set.ContainsKey(v))
          set[v] = 0;
        set[v]++;
      }

      private void Remove(Dictionary<char, int> set, char v)
      {
        set[v]--;
        if (set[v] == 0)
          set.Remove(v);
      }
    }
  }
}
