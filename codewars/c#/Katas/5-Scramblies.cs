using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/55c04b4cc56a697bb0000048
  ///   https://www.codewars.com/kata/reviews/5684fd62a86c6fc9a100002c/groups/5dff64f38c89df0001e5163d
  /// </summary>
  public class Scramblies
  {
    public static bool Scramble(string str1, string str2)
    {
      var map1 = GetMap(str1);
      var map2 = GetMap(str2);

      foreach (var item2 in map2)
      {
        if (!map1.ContainsKey(item2.Key) || map1[item2.Key] < item2.Value)
          return false;
      }

      return true;
    }

    private static Dictionary<char, int> GetMap(string str)
    {
      return str.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
    }
  }
}
