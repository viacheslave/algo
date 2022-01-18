using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/52fb87703c1351ebd200081f
  ///   https://www.codewars.com/kata/reviews/57b9f378aea8e1088200014e/groups/5f8dcd79314b2100017220cf
  /// </summary>
  public class WhatCenturyIsIt
  {
    public class Kata
    {
      public static string WhatCentury(string year)
      {
        if (year.Length <= 2)
          return "1st";

        var y = int.Parse(year);

        var n = y / 100 + (y % 100 == 0 ? 0 : 1);

        if (n != 11 && n % 10 == 1)
          return n + "st";

        if (n != 12 && n % 10 == 2)
          return n + "nd";

        if (n != 13 && n % 10 == 3)
          return n + "rd";

        return n + "th";
      }
    }
  }
}
