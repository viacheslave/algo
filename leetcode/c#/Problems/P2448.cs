namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-cost-to-make-array-equal/
///    Submission: https://leetcode.com/problems/minimum-cost-to-make-array-equal/submissions/830109372/
/// </summary>
internal class P2448
{
  public class Solution
  {
    public long MinCost(int[] nums, int[] cost)
    {
      var arr = nums.Zip(cost).GroupBy(t => t.First)
        .Select(x => (num: x.Key, cost: x.Sum(r => (long)r.Second)))
        .OrderBy(x => x.num)
        .ToArray();

      if (arr.Length == 1)
        return 0;

      // calculate prefixSums
      var prefixSums = new long[arr.Length + 1];
      for (var i = 0; i < arr.Length; i++)
        prefixSums[i + 1] = prefixSums[i] + arr[i].cost;

      var left = new long[arr.Length];
      var right = new long[arr.Length];

      for (var i = 0; i < arr.Length - 1; i++)
        left[i + 1] = (arr[i + 1].num - arr[i].num) * prefixSums[i + 1] + left[i];

      for (var i = arr.Length - 1; i > 0; i--)
        right[i - 1] = (arr[i].num - arr[i - 1].num) * (prefixSums[arr.Length] - prefixSums[i]) + right[i];

      var ans = long.MaxValue;

      for (var i = 0; i < arr.Length; i++)
        ans = Math.Min(ans, left[i] + right[i]);

      return ans;
    }
  }
}
