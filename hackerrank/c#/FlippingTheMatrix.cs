using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class FlippingTheMatrix
  {


    class Result
    {

      /*
       * Complete the 'flippingMatrix' function below.
       *
       * The function is expected to return an INTEGER.
       * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
       */

      public static int flippingMatrix(List<List<int>> matrix)
      {
        var ans = 0;
        var n = matrix.Count / 2;

        for (var i = 0; i < n; i++)
        {
          for (var j = 0; j < n; j++)
          {
            ans += Math.Max(
              Math.Max(matrix[i][j], matrix[2 * n - 1 - i][2 * n - 1 - j]),
              Math.Max(matrix[2 * n - 1 - i][j], matrix[i][2 * n - 1 - j])
            );
          }
        }

        return ans;
      }

    }
    /*
    class Solution
    {
      public static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
          int n = Convert.ToInt32(Console.ReadLine().Trim());

          List<List<int>> matrix = new List<List<int>>();

          for (int i = 0; i < 2 * n; i++)
          {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
          }

          int result = Result.flippingMatrix(matrix);

          textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
