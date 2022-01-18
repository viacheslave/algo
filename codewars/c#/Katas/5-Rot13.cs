using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/530e15517bc88ac656000716
  ///   https://www.codewars.com/kata/reviews/5996a634e06bbf2b5a000569/groups/5f8dd23f56594b0001819ce7
  /// </summary>
  public class Rot13
  {
    public class Kata
    {
      public static string Rot13(string message)
      {
        var sb = new StringBuilder(message);

        for (int i = 0; i < sb.Length; i++)
        {
          if (char.IsLetter(sb[i]))
          {
            var n = char.IsLower(sb[i]) ? sb[i] - 'a' : sb[i] - 'A';
            var res = (n + 26 + 13) % 26;

            sb[i] = char.IsLower(sb[i]) ? (char)(res + 'a') : (char)(res + 'A');
          }
        }

        return sb.ToString();
      }
    }
  }
}
