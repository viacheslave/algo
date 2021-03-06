namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/unique-number-of-occurrences/
///    Submission: https://leetcode.com/submissions/detail/281364421/
/// </summary>
internal class P1207
{
  public class Solution
  {
    public bool UniqueOccurrences(int[] arr)
    {
      var map = arr.GroupBy(a => a)
          .ToDictionary(a => a.Key, a => a.Count());

      return map.Values.Count == map.Values.Distinct().Count();
    }
  }
}
