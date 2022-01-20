using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class BreadthFirstSearchShortestReach
  {


    class Result
    {

      /*
       * Complete the 'bfs' function below.
       *
       * The function is expected to return an INTEGER_ARRAY.
       * The function accepts following parameters:
       *  1. INTEGER n
       *  2. INTEGER m
       *  3. 2D_INTEGER_ARRAY edges
       *  4. INTEGER s
       */

      public static List<int> bfs(int n, int m, List<List<int>> edges, int s)
      {
        var adjList = new Dictionary<int, List<int>>();
        for (var i = 1; i <= n; i++)
        {
          adjList[i] = new List<int>();
        }

        foreach (var edge in edges)
        {
          adjList[edge[0]].Add(edge[1]);
          adjList[edge[1]].Add(edge[0]);
        }

        var a = new int[n];

        // bfs
        var visited = new HashSet<int>();
        var queue = new Queue<(int node, int distance)>();

        queue.Enqueue((s, 0));

        while (queue.Count > 0)
        {
          var el = queue.Dequeue();
          a[el.node - 1] = el.distance;

          foreach (var node in adjList[el.node])
          {
            if (!visited.Contains(node))
            {
              queue.Enqueue((node, el.distance + 1));
              visited.Add(node);
            }
          }
        }

        var ans = a.Select(x => x > 0 ? x * 6 : -1).ToList();
        ans.RemoveAt(s - 1);

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
          string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

          int n = Convert.ToInt32(firstMultipleInput[0]);

          int m = Convert.ToInt32(firstMultipleInput[1]);

          List<List<int>> edges = new List<List<int>>();

          for (int i = 0; i < m; i++)
          {
            edges.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
          }

          int s = Convert.ToInt32(Console.ReadLine().Trim());

          List<int> result = Result.bfs(n, m, edges, s);

          textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
