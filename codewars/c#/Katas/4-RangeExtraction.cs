using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/51ba717bb08c1cd60f00002f
  ///   https://www.codewars.com/kata/reviews/57ce1ccdf17ba36b35000097/groups/5dff4cdf4225f30001f55dd0
  /// </summary>
  public class RangeExtraction
  {
    public static string Extract(int[] args)
    {
      var ranges = new List<string>();

      var range = new List<int>();
      for (var i = 0; i < args.Length; i++)
      {
        if (i == 0)
        {
          range.Add(args[i]);
          continue;
        }

        if (args[i] - args[i - 1] == 1)
        {
          range.Add(args[i]);
          continue;
        }

        ranges.Add(range.Count == 1
          ? $"{range[0]}"
          : (range.Count == 2 ? $"{range[0]},{range[1]}" : $"{range[0]}-{range[range.Count - 1]}"));

        range = new List<int>();
        range.Add(args[i]);
      }

      ranges.Add(range.Count == 1
        ? $"{range[0]}"
        : (range.Count == 2 ? $"{range[0]},{range[1]}" : $"{range[0]}-{range[range.Count - 1]}"));

      return string.Join(",", ranges);
    }
  }
}
