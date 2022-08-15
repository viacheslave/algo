namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-number-of-bad-pairs/
///    Submission: https://leetcode.com/submissions/detail/772564338/
/// </summary>
internal class P2364
{
  public class Solution
  {
    public long CountBadPairs(int[] nums)
    {
      // j - i = num[j] - num[i]
      // num[i] - i = num[j] - j

      var clusters = nums.Select((i, e) => e - i)
        .GroupBy(x => x)
        .Where(x => x.Count() > 1)
        .ToDictionary(x => x.Key, x => x.Count());

      var all = 1L * nums.Length * (nums.Length - 1) / 2;
      var good = 0L;

      foreach (var item in clusters)
      {
        var count = item.Value;
        good += 1L * count * (count - 1) / 2;
      }

      return all - good;
    }
  }
}
