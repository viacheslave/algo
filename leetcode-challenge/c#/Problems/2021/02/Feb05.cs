using System;
using System.Collections.Generic;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/featured/card/february-leetcoding-challenge-2021/584/week-1-february-1st-february-7th/3629/
  ///    https://leetcode.com/submissions/detail/453140488/?from=explore&item_id=3629
  /// </summary>
  internal class Feb05
  {
    public class Solution
    {
      public string SimplifyPath(string path)
      {
        var cur = new List<string>();

        var values = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

        foreach (var value in values)
        {
          if (value == ".")
            continue;

          if (value == "..")
          {
            if (cur.Count > 0)
              cur.RemoveAt(cur.Count - 1);
            continue;
          }

          cur.Add(value);
        }

        return "/" + string.Join('/', cur);
      }
    }
  }
}
