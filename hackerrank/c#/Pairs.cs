using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class Pairs
  {


    class Result
    {

      /*
       * Complete the 'pairs' function below.
       *
       * The function is expected to return an INTEGER.
       * The function accepts following parameters:
       *  1. INTEGER k
       *  2. INTEGER_ARRAY arr
       */

      public static int pairs(int k, List<int> arr)
      {
        var map = arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var ans = 0;

        foreach (var item in arr)
        {
          if (map.TryGetValue(item - k, out int value1))
          {
            ans += value1 * map[item];
          }

          if (map.TryGetValue(item + k, out int value2))
          {
            ans += value2 * map[item];
          }
        }

        return ans / 2;
      }

    }
    /*
    class Solution
    {
      public static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.pairs(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
