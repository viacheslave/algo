namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sum-of-numbers-with-units-digit-k/
///    Submission: https://leetcode.com/submissions/detail/725942735/
/// </summary>
internal class P2310
{
  public class Solution
  {
    public int MinimumNumbers(int num, int k)
    {
      if (num == 0)
      {
        return 0;
      }

      // impossible cases
      if (k % 2 == 0 && num % 2 != 0)
      {
        return -1;
      }

      if (k % 5 == 0 && num % 5 != 0)
      {
        return -1;
      }

      // recursive
      var ans = GetMinSet(num, k);

      if (ans == int.MaxValue)
      {
        return -1;
      }

      return ans;
    }

    private int GetMinSet(int num, int k)
    {
      if (num % 10 == k)
      {
        return 1;
      }

      var ans = int.MaxValue;

      var n = k == 0 ? 10 : k;

      while (n < num)
      {
        ans = Math.Min(ans, GetMinSet(num - n, k));

        // greedy return
        if (ans != int.MaxValue)
        {
          break;
        }

        n += 10;
      }

      return ans == int.MaxValue
        ? int.MaxValue
        : ans + 1;
    }
  }
}
