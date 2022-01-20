using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank;

internal class AVeryBigSum
{
  class Solution
  {

    // Complete the aVeryBigSum function below.
    static long aVeryBigSum(long[] ar)
    {

      return ar.Sum();
    }
    /*
    static void Main(string[] args)
    {
      TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

      int arCount = Convert.ToInt32(Console.ReadLine());

      long[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt64(arTemp))
      ;
      long result = aVeryBigSum(ar);

      textWriter.WriteLine(result);

      textWriter.Flush();
      textWriter.Close();
    }
    */
  }

}
