using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/shortest-word-distance-iii/
  ///    Submission: https://leetcode.com/submissions/detail/451182116/
  ///    Google
  /// </summary>
  internal class P0245
  {
    public class Solution
    {
      public int ShortestWordDistance(string[] words, string word1, string word2)
      {
        var map = new Dictionary<string, List<int>>();

        for (var i = 0; i < words.Length; i++)
        {
          if (!map.ContainsKey(words[i])) map[words[i]] = new List<int>();
          map[words[i]].Add(i);
        }

        if (word1 != word2)
        {
          var ans = int.MaxValue;

          foreach (var i in map[word1])
            foreach (var j in map[word2])
              ans = Math.Min(ans, Math.Abs(j - i));

          return ans;
        }

        var values = map[word1];

        var a = int.MaxValue;
        for (var i = 1; i < values.Count; i++)
          a = Math.Min(a, values[i] - values[i - 1]);

        return a;
      }
    }
  }
}
