﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank;

internal class SimpleArraySum
{
  class Solution
  {

    /*
     * Complete the simpleArraySum function below.
     */
    static int simpleArraySum(int[] ar)
    {
      /*
       * Write your code here.
       */

      return ar.Sum();

    }
    /*
    static void Main(string[] args)
    {
      TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

      int arCount = Convert.ToInt32(Console.ReadLine());

      int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
      ;
      int result = simpleArraySum(ar);

      textWriter.WriteLine(result);

      textWriter.Flush();
      textWriter.Close();
    }
    */
  }

}
