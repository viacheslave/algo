namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/max-sum-of-a-pair-with-equal-sum-of-digits/
///    Submission: https://leetcode.com/submissions/detail/750534717/
/// </summary>
internal class P2342
{
  public class Solution
  {
    public int MaximumSum(int[] nums)
    {
      var sums = nums
        .Select(num => (sum: num.ToString().Sum(ch => int.Parse(ch.ToString())), num: num))
        .ToArray();

      var arr = sums
        .GroupBy(x => x.sum)
        .Select(x => x.OrderBy(f => f.num).ToArray())
        .Where(x => x.Length > 1)
        .Select(x => x[^1].num + x[^2].num)
        .ToArray();

      return arr.Length > 0 ? arr.Max() : -1;
    }
  }
}
