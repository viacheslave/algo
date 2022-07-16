namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-amount-of-time-to-fill-cups/
///    Submission: https://leetcode.com/submissions/detail/743548256/
/// </summary>
internal class P2335
{
  public class Solution
  {
    public int FillCups(int[] amount)
    {
      var ans = 0;
      var sum = amount.Sum();

      while (sum > 0)
      {
        var ordered = amount.Select((n, i) => (n, i)).OrderBy(x => x.n).ToArray();
        var topTwo = new int[] { ordered[1].i, ordered[2].i };

        if (amount[topTwo[0]] > 0 && amount[topTwo[1]] > 0)
        {
          sum -= 2;
          amount[topTwo[0]]--;
          amount[topTwo[1]]--;
        }
        else if (amount[topTwo[0]] > 0)
        {
          sum--;
          amount[topTwo[0]]--;
        }
        else
        {
          sum--;
          amount[topTwo[1]]--;
        }

        ans++;
      }

      return ans;
    }
  }
}
