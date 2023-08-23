namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/merge-similar-items/
///    Submission: https://leetcode.com/submissions/detail/772569311/
/// </summary>
internal class P2363
{
  public class Solution
  {
    public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
    {
      var map = new Dictionary<int, int>();

      foreach (var item in items1)
        map[item[0]] = map.GetValueOrDefault(item[0], 0) + item[1];

      foreach (var item in items2)
        map[item[0]] = map.GetValueOrDefault(item[0], 0) + item[1];

      return map.Select(x => (IList<int>)(new List<int> { x.Key, x.Value }))
        .OrderBy(x => x[0])
        .ToList();
    }
  }
}
