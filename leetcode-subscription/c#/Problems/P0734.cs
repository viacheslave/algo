using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sentence-similarity/
  ///    Submission: https://leetcode.com/submissions/detail/451482505/
  ///    Google
  /// </summary>
  internal class P0734
  {
    public class Solution
    {
      public bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs)
      {
        if (sentence1.Length != sentence2.Length)
          return false;

        var s1 = sentence1.ToList();
        var s2 = sentence2.ToList();

        var pairMap = new HashSet<(string, string)>();

        foreach (var pair in similarPairs)
        {
          pairMap.Add((pair[0], pair[1]));
          pairMap.Add((pair[1], pair[0]));
        }

        var si1 = new int[s1.Count];
        var si2 = new int[s2.Count];

        for (var i = 0; i < sentence1.Length; i++)
        {
          var word1 = sentence1[i];

          for (var j = 0; j < sentence2.Length; j++)
          {
            if (si2[j] == 1)
              continue;

            var word2 = sentence2[j];

            if (word1 == word2 || pairMap.Contains((word1, word2)) || pairMap.Contains((word2, word1)))
            {
              si1[i] = 1;
              si2[j] = 1;
              break;
            }
          }
        }

        return !si1.Any(s => s == 0) && !si2.Any(s => s == 0);
      }
    }
  }
}
