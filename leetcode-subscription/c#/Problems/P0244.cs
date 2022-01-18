using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/shortest-word-distance-ii/
  ///    Submission: https://leetcode.com/submissions/detail/451180511/
  ///    LinkedIn
  /// </summary>
  internal class P0244
  {
    public class WordDistance
    {
      private readonly Dictionary<string, List<int>> _map = new Dictionary<string, List<int>>();

      private readonly Dictionary<(string, string), int> _cache = new Dictionary<(string, string), int>();

      public WordDistance(string[] words)
      {
        _map = new Dictionary<string, List<int>>();

        for (var i = 0; i < words.Length; i++)
        {
          if (!_map.ContainsKey(words[i])) _map[words[i]] = new List<int>();
          _map[words[i]].Add(i);
        }
      }

      public int Shortest(string word1, string word2)
      {
        if (_cache.ContainsKey((word1, word2)))
          return _cache[(word1, word2)];

        var ans = int.MaxValue;

        foreach (var i in _map[word1])
          foreach (var j in _map[word2])
            ans = Math.Min(ans, Math.Abs(j - i));

        _cache[(word1, word2)] = ans;
        _cache[(word2, word1)] = ans;

        return ans;
      }
    }

    /**
     * Your WordDistance object will be instantiated and called as such:
     * WordDistance obj = new WordDistance(words);
     * int param_1 = obj.Shortest(word1,word2);
     */
  }
}
