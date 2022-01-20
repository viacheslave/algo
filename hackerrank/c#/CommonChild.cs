using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class CommonChild
  {


    class Result
    {

      /*
       * Complete the 'commonChild' function below.
       *
       * The function is expected to return an INTEGER.
       * The function accepts following parameters:
       *  1. STRING s1
       *  2. STRING s2
       */

      public static int commonChild(string s1, string s2)
      {
        var dp = new int[s1.Length + 1, s2.Length + 1];

        for (var i = 0; i < s1.Length; i++)
        {
          for (var j = 0; j < s2.Length; j++)
          {
            if (s1[i] == s2[j])
            {
              dp[i + 1, j + 1] = dp[i, j] + 1;
            }
            else
            {
              dp[i + 1, j + 1] = Math.Max(
                dp[i, j + 1],
                dp[i + 1, j]
              );
            }
          }
        }

        return dp[s1.Length, s2.Length];
      }

    }
    /*
    class Solution
    {
      public static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = Result.commonChild(s1, s2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
