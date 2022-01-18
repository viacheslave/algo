using System.Collections.Generic;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/june-leetcoding-challenge-2021/605/week-3-june-15th-june-21st/3781/
  /// 
  /// </summary>
  internal class Jun16
  {
    public class Solution
    {
      public IList<string> GenerateParenthesis(int n)
      {
        var res = new List<string>();

        int strlength = n * 2;

        var items = new List<string>();

        Generate(items, new StringBuilder(new string(' ', strlength)), 0, 0);
        return items;

      }

      private void Generate(IList<string> res, StringBuilder current, int index, int opens)
      {
        if (index == current.Length)
        {
          res.Add(current.ToString());
          return;
        }

        if (index == 0)
        {
          current[index] = '(';
          Generate(res, new StringBuilder(current.ToString()), index + 1, opens + 1);
          return;
        }

        if (opens == current.Length / 2)
        {
          current[index] = ')';
          Generate(res, new StringBuilder(current.ToString()), index + 1, opens);
          return;
        }

        if (opens >= (index + 1) / 2)
        {
          current[index] = '(';
          Generate(res, new StringBuilder(current.ToString()), index + 1, opens + 1);

          current[index] = ')';
          Generate(res, new StringBuilder(current.ToString()), index + 1, opens);
          return;
        }
      }
    }
  }
}
