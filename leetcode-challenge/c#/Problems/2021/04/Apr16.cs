using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3710/
  /// 
  /// </summary>
  internal class Apr16
  {
    public class Solution
    {
      public string RemoveDuplicates(string s, int k)
      {
        var st = new Stack<(char, int)>();

        for (int i = 0; i < s.Length; i++)
        {
          if (st.Count == 0)
          {
            st.Push((s[i], 1));
            continue;
          }

          var last = st.Peek();
          if (last.Item1 == s[i])
            st.Push((s[i], last.Item2 + 1));
          else
            st.Push((s[i], 1));

          if (st.Peek().Item2 == k)
          {
            for (int j = 0; j < k; j++)
            {
              st.Pop();
            }
          }
        }

        var sb = new List<char>();
        while (st.Count > 0)
          sb.Add(st.Pop().Item1);

        sb.Reverse();
        return new string(sb.ToArray());
      }
    }
  }
}
