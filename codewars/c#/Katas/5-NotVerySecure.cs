using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/526dbd6c8c0eb53254000110
  ///   https://www.codewars.com/kata/reviews/599ea6aee50047b3af0029e2/groups/5dff684f4225f30001f56592
  /// </summary>
  public class NotVerySecure
  {
    public class Kata
    {
      public static bool Alphanumeric(string str)
      {
        if (string.IsNullOrEmpty(str)) return false;

        return str.All(ch => (ch >= 48 && ch <= 57)
          || (ch >= 65 && ch <= 90)
          || (ch >= 97 && ch <= 122));
      }
    }
  }
}
