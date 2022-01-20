using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class TheMaximumSubarray
  {

    class Result
    {

      /*
       * Complete the 'maxSubarray' function below.
       *
       * The function is expected to return an INTEGER_ARRAY.
       * The function accepts INTEGER_ARRAY arr as parameter.
       */

      public static List<int> maxSubarray(List<int> arr)
      {
        if (arr.Count == 0)
        {
          return new List<int> { arr[0], arr[0] };
        }

        if (arr.All(x => x >= 0))
        {
          var sum = arr.Sum();
          return new List<int> { sum, sum };
        }

        if (arr.All(x => x < 0))
        {
          var subArray = arr.Max();
          return new List<int> { subArray, subArray };
        }

        var subSeq = arr.Where(x => x >= 0).Sum();

        var max = arr[0];
        var maxCurrent = max;

        for (var i = 1; i < arr.Count; i++)
        {
          maxCurrent = Math.Max(maxCurrent + arr[i], arr[i]);
          max = Math.Max(max, maxCurrent);
        }

        return new List<int> { max, subSeq };
      }
    }
    /*
    class Solution
    {
      public static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
          int n = Convert.ToInt32(Console.ReadLine().Trim());

          List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

          List<int> result = Result.maxSubarray(arr);

          textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
