using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank;

internal class ExtraLongFactorials
{

  class Result
  {

    /*
     * Complete the 'extraLongFactorials' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void extraLongFactorials(int n)
    {
      var b = new System.Numerics.BigInteger(1);
      for (var index = 2; index <= n; index++)
      {
        b = b * index;
      }

      Console.WriteLine(b.ToString());
    }

  }
  /*
  class Solution
  {
    public static void Main(string[] args)
    {
      int n = Convert.ToInt32(Console.ReadLine().Trim());

      Result.extraLongFactorials(n);
    }
  }
  */
}
