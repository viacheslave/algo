using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class _3DSurfaceArea
  {

    class Result
    {

      /*
       * Complete the 'surfaceArea' function below.
       *
       * The function is expected to return an INTEGER.
       * The function accepts 2D_INTEGER_ARRAY A as parameter.
       */

      public static int surfaceArea(List<List<int>> A)
      {
        var rows = A.Count;
        var cols = A[0].Count;

        var area = 0;

        // top + bottom
        area += rows * cols * 2;

        // rows
        foreach (var row in A)
        {
          var current = 0;
          for (var j = 1; j < cols; j++)
          {
            current += Math.Abs(row[j] - row[j - 1]);
          }

          current += row[0];
          current += row[cols - 1];
          area += current;
        }

        for (var j = 0; j < cols; j++)
        {
          var current = 0;

          for (var i = 1; i < rows; i++)
          {
            current += Math.Abs(A[i][j] - A[i - 1][j]);
          }

          current += A[0][j];
          current += A[rows - 1][j];
          area += current;
        }

        return area;
      }

    }
    /*
    class Solution
    {
      public static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int H = Convert.ToInt32(firstMultipleInput[0]);

        int W = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> A = new List<List<int>>();

        for (int i = 0; i < H; i++)
        {
          A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
        }

        int result = Result.surfaceArea(A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
