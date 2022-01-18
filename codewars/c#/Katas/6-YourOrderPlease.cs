using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/55c45be3b2079eccff00010f
  ///   https://www.codewars.com/kata/reviews/59c21cd403a9ad981f000933/groups/5dff42da4ebc2000018a0c83
  /// </summary>
  public class YourOrderPlease
  {
    public static class Kata
    {
      public static string Order(string words)
      {
        if (string.IsNullOrEmpty(words))
          return words;

        var wds = words.Split(' ');

        var map = new SortedDictionary<int, string>();
        foreach (var word in wds)
        {
          var digit = word.First(ch => char.IsDigit(ch));
          map[digit] = word;
        }

        return string.Join(" ", map.Values);
      }
    }
  }
}
