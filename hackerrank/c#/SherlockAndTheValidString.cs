using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class SherlockAndTheValidString
  {

    class Result
    {

      /*
       * Complete the 'isValid' function below.
       *
       * The function is expected to return a STRING.
       * The function accepts STRING s as parameter.
       */

      public static string isValid(string s)
      {
        var map = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        var values = map.Values.OrderBy(x => x).ToArray();
        if (values.Distinct().Count() == 1)
          return "YES";

        for (var i = 0; i < values.Length; i++)
        {
          var arr = new List<int>(values);
          arr[i]--;

          if (arr.Distinct().Where(x => x > 0).Count() == 1)
            return "YES";

          if (arr.All(x => x == 0))
            return "YES";
        }

        return "NO";
      }

    }
    /*
    class Solution
    {
      public static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.isValid(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
