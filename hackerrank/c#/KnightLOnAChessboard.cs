using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class KnightLOnAChessboard
  {


    class Result
    {

      /*
       * Complete the 'knightlOnAChessboard' function below.
       *
       * The function is expected to return a 2D_INTEGER_ARRAY.
       * The function accepts INTEGER n as parameter.
       */

      public static List<List<int>> knightlOnAChessboard(int n)
      {
        var ansMap = new int[n, n];

        for (var a = 1; a < n; a++)
        {
          for (var b = 1; b < n; b++)
          {
            if (ansMap[b, a] != 0)
            {
              ansMap[a, b] = ansMap[b, a];
              continue;
            }

            ansMap[a, b] = Find(n, a, b);
          }
        }

        var ans = new List<List<int>>();

        for (var a = 1; a < n; a++)
        {
          var list = new List<int>();

          for (var b = 1; b < n; b++)
          {
            list.Add(ansMap[a, b]);
          }

          ans.Add(list);
        }

        return ans;
      }

      public static int Find(int n, int a, int b)
      {
        var visited = new HashSet<(int, int)>();
        var queue = new Queue<(int, int, int)>();
        queue.Enqueue((0, 0, 0));

        while (queue.Count > 0)
        {
          var el = queue.Dequeue();
          if (el.Item1 == n - 1 && el.Item2 == n - 1)
            return el.Item3;

          var px = new int[] { -a, -a, -b, -b, b, b, a, a };
          var py = new int[] { b, -b, a, -a, a, -a, b, -b };

          for (var i = 0; i < 8; i++)
          {
            var point = (el.Item1 + px[i], el.Item2 + py[i]);
            if (!visited.Contains((point)))
            {
              if (point.Item1 < 0 || point.Item2 < 0 || point.Item1 >= n || point.Item2 >= n)
                continue;

              visited.Add(point);
              queue.Enqueue((point.Item1, point.Item2, el.Item3 + 1));
            }
          }
        }

        return -1;
      }

    }
    /*
    class Solution
    {
      public static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> result = Result.knightlOnAChessboard(n);

        textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
