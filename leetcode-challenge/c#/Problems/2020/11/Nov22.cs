using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Challenge
{
  /// <summary>
  ///    https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3540/
  ///    https://leetcode.com/submissions/detail/422904234/?from=/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3540/
  /// </summary>
  internal class Nov22
  {
    public class Solution
    {
      private string[] m = new string[] {
        ".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};

      public int UniqueMorseRepresentations(string[] words)
      {
        var hs = new HashSet<string>();

        foreach (var word in words)
          hs.Add(GetMorse(word));

        return hs.Count;
      }

      private string GetMorse(string s)
      {
        var sb = new StringBuilder();

        foreach (var ch in s)
          sb.Append(m[(int)ch - 97]);

        return sb.ToString();
      }
    }
  }
}
