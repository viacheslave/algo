using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/578aa45ee9fd15ff4600090d
  ///   https://www.codewars.com/kata/reviews/57ce1ccdf17ba36b35000097/groups/5dff4cdf4225f30001f55dd0
  /// </summary>
  public class SortTheOdd
  {
    public class Kata
    {
      public static int[] SortArray(int[] array)
      {
        var odds = array.Where(a => a != 0 && a % 2 == 1).ToList();
        odds.Sort();

        var oindex = 0;
        for (var i = 0; i < array.Length; i++)
        {
          if (array[i] != 0 && array[i] % 2 == 1)
          {
            array[i] = odds[oindex];
            oindex++;
          }
        }

        return array;
      }
    }
  }
}
