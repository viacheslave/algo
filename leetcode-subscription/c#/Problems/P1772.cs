using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sort-features-by-popularity/
  ///    Submission: https://leetcode.com/submissions/detail/461699108/
  ///    Amazon
  /// </summary>
  internal class P1772
  {
    public class Solution
    {
      public string[] SortFeatures(string[] features, string[] responses)
      {
        var featureSet = features.ToHashSet();
        var map = featureSet.ToDictionary(x => x, x => 0);

        foreach (var response in responses)
        {
          var words = response.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToHashSet();
          foreach (var word in words)
          {
            if (featureSet.Contains(word))
              map[word]++;
          }
        }

        var kvp = map.Select(x => (name: x.Key, count: x.Value, ind: Array.IndexOf(features, x.Key)));

        return kvp
          .OrderByDescending(x => x.count)
          .ThenBy(x => x.ind)
          .Select(x => x.name)
          .ToArray();
      }
    }
  }
}
