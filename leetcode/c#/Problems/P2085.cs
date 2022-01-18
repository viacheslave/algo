namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-common-words-with-one-occurrence/
///    Submission: https://leetcode.com/submissions/detail/593894595/
/// </summary>
internal class P2085
{
  public class Solution
  {
    public int CountWords(string[] words1, string[] words2)
    {
      return GetDistinct(words1)
        .Intersect(GetDistinct(words2))
        .Count();

      static HashSet<string> GetDistinct(string[] words1)
      {
        return words1
          .GroupBy(x => x)
          .ToDictionary(x => x.Key, x => x.Count())
          .Where(x => x.Value == 1)
          .Select(x => x.Key)
          .ToHashSet();
      }
    }
  }
}
