using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class MinimumAbsoluteDifference
  {

    class Result
    {

      /*
       * Complete the 'minimumAbsoluteDifference' function below.
       *
       * The function is expected to return an INTEGER.
       * The function accepts INTEGER_ARRAY arr as parameter.
       */

      public static int minimumAbsoluteDifference(List<int> arr)
      {
        arr.Sort();

        var ans = int.MaxValue;
        for (var i = 1; i < arr.Count; i++)
          ans = Math.Min(ans, Math.Abs(arr[i] - arr[i - 1]));

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

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.minimumAbsoluteDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
