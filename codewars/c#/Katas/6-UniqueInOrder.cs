using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/54e6533c92449cc251001667
  ///   https://www.codewars.com/kata/reviews/59b1fff4837809ac630001f2/groups/5dff465e884174000122062e
  /// </summary>
  public class UniqueInOrder
  {
    public static class Kata
    {
      public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
      {
        var ans = new List<T>();
        foreach (var item in iterable)
        {
          if (ans.Count == 0)
          {
            ans.Add(item);
            continue;
          }

          if (ans[ans.Count - 1].Equals(item))
            continue;

          ans.Add(item);
        }

        return ans;
      }
    }
  }
}
