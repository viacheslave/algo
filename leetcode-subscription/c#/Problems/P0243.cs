using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/shortest-word-distance/
  ///    Submission: https://leetcode.com/submissions/detail/451178670/
  ///    Microsoft
  /// </summary>
  internal class P0243
  {
    public class Solution
    {
      public int ShortestDistance(string[] words, string word1, string word2)
      {
        var map = new Dictionary<string, List<int>>();

        for (var i = 0; i < words.Length; i++)
        {
          if (!map.ContainsKey(words[i])) map[words[i]] = new List<int>();
          map[words[i]].Add(i);
        }

        var ans = int.MaxValue;

        foreach (var i in map[word1])
          foreach (var j in map[word2])
            ans = Math.Min(ans, Math.Abs(j - i));

        return ans;
      }
    }
  }
}
