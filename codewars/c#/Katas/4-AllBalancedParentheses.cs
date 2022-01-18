using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/5426d7a2c2c7784365000783
  ///   https://www.codewars.com/kata/reviews/5d6ab513476ab30001ddaaab/groups/5f8dd6983853d200013e49b4
  /// </summary>
  public class Balanced
  {
    public static List<string> BalancedParens(int n)
    {
      var res = new List<string>();

      int strlength = n * 2;

      var items = new List<string>();

      Generate(items, new StringBuilder(new string(' ', strlength)), 0, 0);
      return items;
    }

    private static void Generate(IList<string> res, StringBuilder current, int index, int opens)
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
