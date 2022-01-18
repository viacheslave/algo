using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/51e056fe544cf36c410000fb
  ///   https://www.codewars.com/kata/reviews/5d617c13344de600012b938e/groups/5e04d2ec4225f30001a5a1a0
  /// </summary>
  public class TopWords
  {
    public static List<string> Top3(string s)
    {
      return new Regex("([a-zA-Z'])*", RegexOptions.IgnoreCase).Matches(s)
        .Where(m => m.Length > 0)
        .Select(m => m.Value)
        .Where(m => m.Any(ch => Char.IsLetter(ch)))
        .GroupBy(word => word.ToLower())
        .ToDictionary(g => g.Key, g => g.Count())
        .OrderByDescending(d => d.Value)
        .Take(3)
        .Select(w => w.Key)
        .ToList();
    }
  }
}
