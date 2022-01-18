using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///   https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/586/week-3-february-15th-february-21st/3645/
  ///    
  /// </summary>
  internal class Feb19
  {
    public class Solution
    {
      public string MinRemoveToMakeValid(string s)
      {
        var open = 0;
        var close = 0;
        var arr = s.ToCharArray().ToList();

        var removedLeft = new List<int>();
        var removedRight = new List<int>();

        for (var i = 0; i < arr.Count; i++)
        {
          if (arr[i] != '(' && arr[i] != ')')
            continue;

          if (arr[i] == '(')
            open++;

          if (arr[i] == ')')
          {
            if (open <= close)
              removedLeft.Add(i);
            else
              close++;
          }
        }

        for (var i = removedLeft.Count - 1; i >= 0; i--)
          arr.RemoveAt(removedLeft[i]);

        open = close = 0;

        for (var i = arr.Count - 1; i >= 0; i--)
        {
          if (arr[i] != '(' && arr[i] != ')')
            continue;

          if (arr[i] == ')')
            open++;

          if (arr[i] == '(')
          {
            if (open <= close)
              removedRight.Add(i);
            else
              close++;
          }
        }

        for (var i = 0; i < removedRight.Count; i++)
          arr.RemoveAt(removedRight[i]);

        return new string(arr.ToArray());
      }
    }
  }
}
