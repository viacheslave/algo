using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/54ba84be607a92aa900000f1
  ///   https://www.codewars.com/kata/reviews/5990dcc010038a3057000289/groups/5990fbcaf98f0ef3cb001052
  /// </summary>
  public class Isograms
  {
    public class Kata
    {
      public static bool IsIsogram(string str)
      {
        return str.ToLower().Distinct().Count() == str.Length;
      }
    }
  }
}
