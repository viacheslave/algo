using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/5839edaa6754d6fec10000a2
  ///   https://www.codewars.com/kata/reviews/5839f6c3cd2acc3167000056/groups/5dff40c9bb26620001622cc1
  /// </summary>
  public class FindTheMissingLetter
  {
    public class Kata
    {
      public static char FindMissingLetter(char[] array)
      {
        for (var i = 0; i < array.Length - 1; i++)
        {
          if ((int)array[i] + 2 == (int)array[i + 1])
          {
            return (char)((int)array[i] + 1);
          }
        }

        return ' ';
      }
    }
  }
}
