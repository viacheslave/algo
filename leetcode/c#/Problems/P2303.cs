namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/calculate-amount-paid-in-taxes/
///    Submission: https://leetcode.com/submissions/detail/721058120/
/// </summary>
internal class P2303
{
  public class Solution
  {
    public double CalculateTax(int[][] brackets, int income)
    {
      var ans = 0d;

      for (var i = 0; i < brackets.Length; i++)
      {
        if (income == 0)
        {
          break;
        }

        var taxable = Math.Min(
          income,
          brackets[i][0] - (i == 0 ? 0 : brackets[i - 1][0]));

        var tax = taxable * brackets[i][1] * 0.01;
        ans += tax;

        income -= taxable;
      }

      return ans;
    }
  }
}
