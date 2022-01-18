using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/5a045fee46d843effa000070
  ///   https://www.codewars.com/kata/reviews/5aec135f1b3c31b78a0016e1/groups/5e01eb0a8c89df000187f64b
  /// </summary>
  class FactDecomp
  {
    public static string Decomp(int n)
    {
      var map = new SortedDictionary<int, int>();

      for (var m = 2; m <= n; m++)
      {
        var current = 2;
        var number = m;

        while (number > 1)
        {
          while (number % current == 0)
          {
            if (!map.ContainsKey(current)) map[current] = 0;

            map[current]++;
            number = number / current;
          }

          current++;
        }
      }

      var str = string.Join(" * ", map.Select(item => item.Value > 1 ? $"{item.Key}^{item.Value}" : $"{item.Key}"));
      return str;
    }
  }
}
