using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/december-leetcoding-challenge/571/week-3-december-15th-december-21st/3572/
  ///    https://leetcode.com/submissions/detail/432567386/?from=explore&item_id=3572
  /// </summary>
  internal class Dec20
  {
    public class Solution
    {
      public string DecodeAtIndex(string S, int K)
      {
        var stack = new Stack<(char ch, long length)>();
        var index = 0;
        var length = 0L;

        while (index < S.Length)
        {
          length = char.IsLetter(S[index])
            ? length + 1
            : length * int.Parse(S[index].ToString());

          // for every index, save running length
          stack.Push((S[index], length));

          if (K <= length)
            break;

          index++;
        }

        long k = K;

        // unwind stack
        // if stack item is letter - just pop it and check if searched position equals to running length
        // if stack item is digit - calculate length of the part that's repeated, adjust searched position with the running length part
        while (stack.Count > 0)
        {
          var item = stack.Pop();

          if (char.IsLetter(item.ch))
          {
            if (k == item.length)
              return item.ch.ToString();
          }
          else
          {
            var repeats = int.Parse(item.ch.ToString());
            var partLength = item.length / repeats;

            while (k > partLength)
              k -= partLength;
          }
        }

        // never happens
        return "";
      }
    }
  }
}
