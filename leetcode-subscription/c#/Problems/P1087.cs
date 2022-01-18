using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/brace-expansion/
  ///    Submission: https://leetcode.com/submissions/detail/236089384/
  ///    Amazon
  /// </summary>
  internal class P1087
  {
    public class Solution
    {
      public string[] Permute(string S)
      {
        var d = new List<List<string>>();

        var curlyStart = -1;

        for (var i = 0; i < S.Length; i++)
        {
          if (S[i] == '{')
          {
            curlyStart = i;
            continue;
          }

          if (S[i] == '}')
          {
            var ss = S.Substring(curlyStart + 1, i - 1 - curlyStart).Split(',').ToList();
            d.Add(new List<string>(ss));
            curlyStart = -1;
            continue;
          }

          if (curlyStart == -1)
            d.Add(new List<string>() { S[i].ToString() });
        }

        var ch = new List<string>();
        var v = new char[d.Count];

        Pick(ch, v, d, 0);

        return ch.OrderBy(a => a).ToArray();
      }

      void Pick(List<string> res, char[] ch, List<List<string>> vars, int index)
      {
        if (index == vars.Count)
        {
          res.Add(new string(ch));
          return;
        }

        foreach (var letter in vars[index])
        {
          ch[index] = char.Parse(letter);

          Pick(res, ch, vars, index + 1);
        }
      }
    }
  }
}
