namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/kth-distinct-string-in-an-array/
///    Submission: https://leetcode.com/submissions/detail/583535648/
/// </summary>
internal class P2053
{
  public class Solution
  {
    public string KthDistinct(string[] arr, int k)
    {
      var distinct = arr.GroupBy(x => x)
        .ToDictionary(x => x.Key, x => x.ToList())
        .Where(x => x.Value.Count == 1)
        .Select(x => x.Key)
        .ToHashSet();

      var count = 0;

      foreach (var a in arr)
      {
        if (distinct.Contains(a))
          count++;

        if (count == k)
          return a;
      }

      return "";
    }
  }
}
