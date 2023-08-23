namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/convert-an-array-into-a-2d-array-with-conditions/
///    Submission: https://leetcode.com/problems/convert-an-array-into-a-2d-array-with-conditions/submissions/926591013/
/// </summary>
internal class P2610
{
  public class Solution
  {
    public IList<IList<int>> FindMatrix(int[] nums)
    {
      var buckets = new Dictionary<int, int>();

      foreach (var item in nums)
        buckets[item] = buckets.GetValueOrDefault(item, 0) + 1;

      var ans = new List<IList<int>>();
      var max = buckets.Max(x => x.Value);

      for (int i = 0; i < max; i++)
      {
        ans.Add(new List<int>());
      }

      foreach (var item in buckets)
        for (var row = 0; row < item.Value; row++)
          ans[row].Add(item.Key);

      return ans;
    }
  }
}
