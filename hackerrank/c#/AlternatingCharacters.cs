using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class AlternatingCharacters
  {


    class Result
    {

      /*
       * Complete the 'alternatingCharacters' function below.
       *
       * The function is expected to return an INTEGER.
       * The function accepts STRING s as parameter.
       */

      public static int alternatingCharacters(string s)
      {
        var repeating = 0;
        var ans = 0;

        for (var i = 0; i < s.Length; i++)
        {
          if (i == 0)
          {
            repeating = 1;
            continue;
          }

          if (s[i - 1] == s[i])
          {
            repeating++;

            if (repeating > 0)
              ans++;
          }
          else
          {
            repeating = 0;
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
          string s = Console.ReadLine();

          int result = Result.alternatingCharacters(s);

          textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
