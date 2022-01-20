using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class LuckBalance
  {

    class Result
    {

      /*
       * Complete the 'luckBalance' function below.
       *
       * The function is expected to return an INTEGER.
       * The function accepts following parameters:
       *  1. INTEGER k
       *  2. 2D_INTEGER_ARRAY contests
       */

      public static int luckBalance(int k, List<List<int>> contests)
      {
        var nonImportantLuck = contests.Where(x => x[1] == 0).Select(x => x[0]).Sum();

        var importantContests = contests
          .Where(c => c[1] == 1)
          .OrderByDescending(x => x[0]).ToList();

        var importantLuck = importantContests.Take(k).Select(x => x[0]).Sum();

        var negative = 0;
        if (k < importantContests.Count)
        {
          negative = importantContests.Where(x => x[1] == 1).Skip(k).Select(x => x[0]).Sum();
        }

        return nonImportantLuck + importantLuck - negative;
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

        List<List<int>> contests = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
          contests.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(contestsTemp => Convert.ToInt32(contestsTemp)).ToList());
        }

        int result = Result.luckBalance(k, contests);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
