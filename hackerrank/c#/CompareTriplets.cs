using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class CompareTriplets
  {
    class Solution
    {

      // Complete the compareTriplets function below.
      static List<int> compareTriplets(List<int> a, List<int> b)
      {

        var ans = new List<int>() { 0, 0 };

        for (var i = 0; i < a.Count; i++)
        {
          if (a[i] < b[i]) ans[1]++;
          if (a[i] > b[i]) ans[0]++;
        }

        return ans;
      }
      /*
      static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> b = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(bTemp => Convert.ToInt32(bTemp)).ToList();

        List<int> result = compareTriplets(a, b);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
      }
      */
    }
  }
}
