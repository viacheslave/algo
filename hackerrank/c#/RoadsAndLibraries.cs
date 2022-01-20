using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class RoadsAndLibraries
  {

    class Result
    {

      /*
       * Complete the 'roadsAndLibraries' function below.
       *
       * The function is expected to return a LONG_INTEGER.
       * The function accepts following parameters:
       *  1. INTEGER n
       *  2. INTEGER c_lib
       *  3. INTEGER c_road
       *  4. 2D_INTEGER_ARRAY cities
       */

      public static long roadsAndLibraries(int n, int c_lib, int c_road, List<List<int>> cities)
      {
        // Write your code here

        var adj = new Dictionary<int, List<int>>();

        for (var i = 1; i <= n; i++)
        {
          adj[i] = new List<int>();
        }

        foreach (var edge in cities)
        {
          adj[edge[0]].Add(edge[1]);
          adj[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();
        var cost = 0L;

        for (var i = 1; i <= n; i++)
        {
          if (visited.Contains(i))
            continue;

          visited.Add(i);

          var towns = 0;

          // bfs
          var queue = new Queue<int>();
          queue.Enqueue(i);

          while (queue.Count > 0)
          {
            var city = queue.Dequeue();
            towns++;

            foreach (var a in adj[city])
            {
              if (!visited.Contains(a))
              {
                visited.Add(a);
                queue.Enqueue(a);
              }
            }
          }

          var minCost = int.MaxValue;

          for (var l = 1; l <= towns; l++)
          {
            var value = l * c_lib + (towns - l) * c_road;
            minCost = Math.Min(minCost, value);
          }

          cost += minCost;
        }

        return cost;
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
          string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

          int n = Convert.ToInt32(firstMultipleInput[0]);

          int m = Convert.ToInt32(firstMultipleInput[1]);

          int c_lib = Convert.ToInt32(firstMultipleInput[2]);

          int c_road = Convert.ToInt32(firstMultipleInput[3]);

          List<List<int>> cities = new List<List<int>>();

          for (int i = 0; i < m; i++)
          {
            cities.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(citiesTemp => Convert.ToInt32(citiesTemp)).ToList());
          }

          long result = Result.roadsAndLibraries(n, c_lib, c_road, cities);

          textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
