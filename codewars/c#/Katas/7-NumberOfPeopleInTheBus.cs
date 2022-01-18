using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/5648b12ce68d9daa6b000099
  ///   https://www.codewars.com/kata/reviews/5648b12f301cdd31e7000099/groups/5dff3ddc4225f30001f55d12
  /// </summary>
  public class NumberOfPeopleInTheBus
  {
    public class Kata
    {
      public static int Number(List<int[]> peopleListInOut)
      {
        var ans = 0;

        for (var i = 0; i < peopleListInOut.Count; i++)
        {
          ans += peopleListInOut[i][0];
          ans -= peopleListInOut[i][1];
        }

        return ans;
      }
    }
  }
}
