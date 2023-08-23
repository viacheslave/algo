namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/maximum-or/
///    Submission: https://leetcode.com/problems/maximum-or/submissions/958961361/
/// </summary>
internal class P2680
{
  public class Solution
  {
    public long MaximumOr(int[] nums, int k)
    {
      var digitCount = new int[31];

      foreach (var num in nums)
      {
        var index = 0;
        var n = num;

        while (n > 0)
        {
          digitCount[index] += n % 2;
          index++;
          n >>= 1;
        }
      }

      // check every num
      var ans = 0L;

      foreach (var num in nums)
      {
        var n = num;

        var rem = 0;
        for (int i = 0; i < 31; i++)
        {
          var count = digitCount[i];
          count -= (n % 2);

          if (count > 0)
          {
            rem += (int)Math.Pow(2, i);
          }

          n >>= 1;
        }

        var applied = num * (long)Math.Pow(2, k);
        ans = Math.Max(ans, applied | rem);
      }

      return ans;
    }
  }
}
