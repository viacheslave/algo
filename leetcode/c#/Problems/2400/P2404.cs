namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/most-frequent-even-element/
///    Submission: https://leetcode.com/submissions/detail/797396800/
/// </summary>
internal class P2404
{
  public class Solution
  {
    public int MostFrequentEven(int[] nums)
    {
      var els = nums.Where(f => f % 2 == 0)
        .GroupBy(g => g)
        .ToDictionary(d => d.Key, d => d.Count())
        .OrderByDescending(d => d.Value)
        .ThenBy(d => d.Key)
        .ToArray();

      if (els.Length == 0)
        return -1;

      return els
        .First()
        .Key;
    }
  }
}
