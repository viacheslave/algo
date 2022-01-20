using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class MaxMin
  {

    class Result
    {

      /*
       * Complete the 'maxMin' function below.
       *
       * The function is expected to return an INTEGER.
       * The function accepts following parameters:
       *  1. INTEGER k
       *  2. INTEGER_ARRAY arr
       */

      public static int maxMin(int k, List<int> arr)
      {
        arr.Sort();

        var ans = int.MaxValue;

        for (var i = 0; i < arr.Count - k + 1; i++)
          ans = Math.Min(ans, arr[i + k - 1] - arr[i]);

        return ans;
      }

    }
    /*
    class Solution
    {
      public static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < n; i++)
        {
          int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
          arr.Add(arrItem);
        }

        int result = Result.maxMin(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
