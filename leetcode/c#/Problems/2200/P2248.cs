namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/intersection-of-multiple-arrays/
///    Submission: https://leetcode.com/submissions/detail/688007674/
/// </summary>
internal class P2248
{
  public class Solution
  {
    public IList<int> Intersection(int[][] nums)
    {
      return nums
        .SelectMany(x => x)
        .GroupBy(x => x)
        .ToDictionary(x => x.Key, x => x.Count())
        .Where(x => x.Value == nums.Length)
        .Select(x => x.Key)
        .OrderBy(x => x)
        .ToList();
    }
  }
}
