using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class SherlockAndAnagrams
  {
    class Result
    {

      /*
       * Complete the 'sherlockAndAnagrams' function below.
       *
       * The function is expected to return an INTEGER.
       * The function accepts STRING s as parameter.
       */

      public static int sherlockAndAnagrams(string s)
      {
        var n = s.Length;
        var ans = 0;

        for (var l = 1; l <= n; l++)
        {
          var maps = new List<int[]>();

          for (var i = 0; i < n - l + 1; i++)
          {
            var arr = new int[26];
            var sub = s.Substring(i, l);

            for (var k = 0; k < sub.Length; k++)
              arr[sub[k] - 97]++;

            maps.Add(arr);
          }

          for (var i = 0; i < maps.Count - 1; i++)
          {
            for (var k = i + 1; k < maps.Count; k++)
            {
              var m1 = maps[i];
              var m2 = maps[k];

              var res = Enumerable.Range(0, 26).All(y => m1[y] == m2[y]);
              if (res)
                ans++;
            }
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

          int result = Result.sherlockAndAnagrams(s);

          textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
