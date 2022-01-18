using System.Collections.Generic;

namespace LeetCode.Challenge.Y21
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/581/week-3-january-15th-january-21st/3610/
  ///    https://leetcode.com/submissions/detail/447102988/?from=explore&item_id=3610
  /// </summary>
  internal class Jan20
  {
    public class Solution
    {
      public bool IsValid(string s)
      {
        Dictionary<char, char> keys = new Dictionary<char, char>
        {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'}
        };

        Stack<char> stack = new Stack<char>();

        char next = default(char);
        bool opened = false;

        foreach (var ch in s)
        {
          if (keys.ContainsKey(ch))
          {
            stack.Push(ch);
            continue;
          }

          if (stack.Count > 0 && keys[stack.Peek()] == ch)
          {
            stack.Pop();
          }
          else
          {
            return false;
          }

        }

        return stack.Count == 0;
      }
    }
  }
}

