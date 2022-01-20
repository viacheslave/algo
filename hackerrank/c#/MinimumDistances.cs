using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class MinimumDistances
  {

    class Solution
    {

      // Complete the minimumDistances function below.
      static int minimumDistances(int[] a)
      {
        var sets = new Dictionary<int, int>();

        var ans = int.MaxValue;

        for (var i = 0; i < a.Length; i++)
        {
          if (!sets.ContainsKey(a[i]))
            sets[a[i]] = i;

          else
          {
            ans = Math.Min(ans, i - sets[a[i]]);
            sets[a[i]] = i;
          }
        }

        return ans == int.MaxValue ? -1 : ans; ;

      }
      /*
      static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
        int result = minimumDistances(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
      }
      */
    }

  }
}
