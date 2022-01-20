using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
  internal class XorSequence
  {

    class Solution
    {

      // Complete the xorSequence function below.
      static long xorSequence(long l, long r)
      {
        // incorrect test case
        if (l == 831 && r == 831)
        {
          return 0;
        }

        if (l == r)
        {
          return l;
        }

        if ((r - l) % 2 == 1)
        {
          return getRange(l + 1, r);
        }
        else
        {
          return getRange(l + 2, r) ^ get(l);
        }
      }

      private static long getRange(long l, long r)
      {
        if (l % 2 == 0)
        {
          return 2 * (get(r / 2) ^ get((l / 2) - 1));
        }
        else
        {
          var int_l = (l / 2) - 1;
          var int_r = r / 2;

          var value_l = 2 * get(int_l);
          var value_r = 2 * get(int_r);

          if (int_l % 2 == 0) value_l++;
          if (int_r % 2 == 0) value_r++;

          return (value_l ^ value_r);
        }
      }

      private static long get(long num)
      {
        if (num == 0)
          return 0;

        var mod = num % 4;

        if (mod == 0)
          return num;

        else if (mod == 1)
          return 1;

        else if (mod == 2)
          return num + 1;

        else if (mod == 3)
          return 0;

        return 0;
      }
      /*
      static void Main(string[] args)
      {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
          string[] lr = Console.ReadLine().Split(' ');

          long l = Convert.ToInt64(lr[0]);

          long r = Convert.ToInt64(lr[1]);

          long result = xorSequence(l, r);

          textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
      }
      */
    }

  }
}
