using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/design-compressed-string-iterator/
  ///    Submission: https://leetcode.com/submissions/detail/453160335/
  ///    Google, Amazon
  /// </summary>
  internal class P0604
  {
    public class StringIterator
    {
      private List<(char ch, int rep)> _chs;
      private int _pos = 0;
      private int _rep = 0;

      public StringIterator(string compressedString)
      {
        _chs = new List<(char ch, int rep)>();

        var ch = default(char);
        var buffer = new List<char>();
        for (var i = 0; i < compressedString.Length; i++)
        {
          if (char.IsLetter(compressedString[i]))
          {
            if (ch != default)
            {
              _chs.Add((ch, int.Parse(new string(buffer.ToArray()))));
              buffer.Clear();
            }

            ch = compressedString[i];
          }
          else
          {
            buffer.Add(compressedString[i]);
          }
        }

        _chs.Add((ch, int.Parse(new string(buffer.ToArray()))));
      }

      public char Next()
      {
        if (_pos == _chs.Count)
          return ' ';

        var ans = _chs[_pos].ch;

        if (_rep == _chs[_pos].rep - 1)
        {
          _pos++;
          _rep = 0;
        }
        else
        {
          _rep++;
        }

        return ans;
      }

      public bool HasNext()
      {
        return !(_pos == _chs.Count);
      }
    }
  }
}
