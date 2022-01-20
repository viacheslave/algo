﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class TwoStrings
  {

    class Result
    {

      /*
       * Complete the 'twoStrings' function below.
       *
       * The function is expected to return a STRING.
       * The function accepts following parameters:
       *  1. STRING s1
       *  2. STRING s2
       */

      public static string twoStrings(string s1, string s2)
      {
        var res = s1.Distinct().Intersect(s2.Distinct()).Any();
        return res ? "YES" : "NO";
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
          string s1 = Console.ReadLine();

          string s2 = Console.ReadLine();

          string result = Result.twoStrings(s1, s2);

          textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
      }
    }
    */
  }
}
