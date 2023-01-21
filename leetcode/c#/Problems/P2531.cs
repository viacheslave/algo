namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/make-number-of-distinct-characters-equal/
///    Submission: https://leetcode.com/problems/make-number-of-distinct-characters-equal/submissions/881952353/
/// </summary>
internal class P2531
{
  public class Solution
  {
    public bool IsItPossible(string word1, string word2)
    {
      var map1 = word1.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
      var map2 = word2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

      // take all possible pairs

      var keys1 = map1.Keys.ToHashSet();
      var keys2 = map2.Keys.ToHashSet();

      foreach (var k1 in keys1)
      {
        foreach (var k2 in keys2)
        {
          if (k1 == k2)
          {
            if (keys1.Count == keys2.Count)
              return true;

            continue;
          }

          var n1 = map1.Keys.Count;
          var n2 = map2.Keys.Count;

          if (map1[k1] == 1) n1--;
          if (map2[k2] == 1) n2--;

          if (!map1.ContainsKey(k2)) n1++;
          if (!map2.ContainsKey(k1)) n2++;

          if (n1 == n2)
          {
            return true;
          }
        }
      }

      return false;
    }
  }
}
