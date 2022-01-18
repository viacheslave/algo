using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/read-n-characters-given-read4/
  ///    Submission: https://leetcode.com/submissions/detail/452103721/
  ///    All
  /// </summary>
  internal class P0157
  {
    /**
     * The Read4 API is defined in the parent class Reader4.
     *     int Read4(char[] buf4);
     */

    public class Solution : Reader4
    {
      /**
       * @param buf Destination buffer
       * @param n   Number of characters to read
       * @return    The number of actual characters read
       */
      public int Read(char[] buf, int n)
      {
        if (n == 0)
          return 0;

        var pos = 0;

        while (true)
        {
          var buffer = new char[4];
          var read = Read4(buffer);

          if (read == 0)
            break;

          var reach = false;

          for (var i = 0; i < read; i++)
          {
            buf[pos] = buffer[i];
            pos++;

            if (pos == n)
            {
              reach = true;
              break;
            }
          }

          if (reach)
            break;
        }

        return pos;
      }
    }

    public class Reader4
    {
      public int Read4(char[] buffer)
      {
        throw new NotImplementedException();
      }
    }
  }
}
