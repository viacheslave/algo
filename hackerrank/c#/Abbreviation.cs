using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class Abbreviation
  {

    class Result
    {

      /*
       * Complete the 'abbreviation' function below.
       *
       * The function is expected to return a STRING.
       * The function accepts following parameters:
       *  1. STRING a
       *  2. STRING b
       */

      public static string abbreviation(string a, string b)
      {
        var dp = new bool[a.Length + 1, b.Length + 1];

        dp[0, 0] = true;

        for (var i = 0; i < a.Length; i++)
        {
          dp[i + 1, 0] = char.IsLower(a[i]) ? dp[i, 0] : false;
        }

        for (var i = 0; i < b.Length; i++)
        {
          dp[0, i + 1] = false;
        }

        for (var i = 0; i < a.Length; i++)
        {
          for (var j = 0; j < b.Length; j++)
          {
            if (a[i] == b[j])
            {
              dp[i + 1, j + 1] = dp[i, j];
            }
            else
            {
              dp[i + 1, j + 1] =
                (char.IsLower(a[i]) && dp[i, j + 1]) ||
                (char.ToLower(a[i]) == char.ToLower(b[j]) && dp[i, j]);
            }
          }
        }

        return dp[a.Length, b.Length] ? "YES" : "NO";
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
          string a = Console.ReadLine();

          string b = Console.ReadLine();

          string result = Result.abbreviation(a, b);

          textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
