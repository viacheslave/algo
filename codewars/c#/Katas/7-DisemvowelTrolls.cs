using System;
using System.Collections.Generic;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/52fba66badcd10859f00097e
  ///   https://www.codewars.com/kata/reviews/550af1f4595138841700089f/groups/5dff34604225f30001f55cb8
  /// </summary>
  public class DisemvowelTrolls
  {
    public static class Kata
    {
      public static string Disemvowel(string str)
      {
        var chars = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        var sb = new StringBuilder(str);
        for (var i = sb.Length - 1; i >= 0; i--)
        {
          if (chars.Contains(sb[i]))
            sb.Remove(i, 1);
        }

        return sb.ToString();
      }
    }
  }
}
