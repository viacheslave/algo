namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/nth-digit/
///    Submission: https://leetcode.com/submissions/detail/227822117/
/// </summary>
internal class P0400
{
  public class Solution
  {
    public int FindNthDigit(int n)
    {
      if (n <= 9)
        return n;

      var start = 9;
      var range = 2;

      while (n > start + (9 * (long)Math.Pow(10, (range - 1))) * (range))
      {
        var pow = Math.Pow(10, range);
        if (int.MaxValue < pow)
          break;

        start += (9 * (int)Math.Pow(10, (range - 1))) * (range);
        range++;
      }

      var coeff = (n - 1 - start) / range;
      var mod = (n - 1 - start) % range;

      var num = Math.Pow(10, (range - 1)) + coeff;

      return int.Parse((num.ToString()[mod]).ToString());
    }
  }
}
