using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/logger-rate-limiter/
  ///    Submission: https://leetcode.com/submissions/detail/451937412/
  ///    All
  /// </summary>
  internal class P0359
  {
    public class Logger
    {
      private Dictionary<string, int> _times = new Dictionary<string, int>();

      /** Initialize your data structure here. */
      public Logger()
      {

      }

      /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
          If this method returns false, the message will not be printed.
          The timestamp is in seconds granularity. */
      public bool ShouldPrintMessage(int timestamp, string message)
      {
        if (!_times.ContainsKey(message))
        {
          _times.Add(message, timestamp);
          return true;
        }

        if (_times[message] + 10 > timestamp)
          return false;

        _times[message] = timestamp;
        return true;
      }
    }
  }
}
