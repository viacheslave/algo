using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class Candies
  {


    class Result
    {

      /*
       * Complete the 'candies' function below.
       *
       * The function is expected to return a LONG_INTEGER.
       * The function accepts following parameters:
       *  1. INTEGER n
       *  2. INTEGER_ARRAY arr
       */

      public static long candies(int n, List<int> arr)
      {
        var left = new long[arr.Count];
        var right = new long[arr.Count];

        left[0] = 1;
        right[right.Length - 1] = 1;

        for (var i = 1; i < arr.Count; i++)
          left[i] = arr[i] > arr[i - 1] ? left[i - 1] + 1 : 1;

        for (var i = arr.Count - 2; i >= 0; i--)
          right[i] = arr[i] > arr[i + 1] ? right[i + 1] + 1 : 1;

        var candy = new long[arr.Count];

        for (var i = 0; i < arr.Count; i++)
          candy[i] = Math.Max(left[i], right[i]);

        return candy.Sum();
      }

    }
    /*
    class Solution
    {
      public static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < n; i++)
        {
          int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
          arr.Add(arrItem);
        }

        long result = Result.candies(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
