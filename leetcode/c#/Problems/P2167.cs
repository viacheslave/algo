namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-time-to-remove-all-cars-containing-illegal-goods/
///    Submission: https://leetcode.com/submissions/detail/635706432/
/// </summary>
internal class P2167
{
  public class Solution
  {
    public int MinimumTime(string s)
    {
      // type 3 cost
      const int any = 2;

      var left = new int[s.Length];
      var right = new int[s.Length];

      var n = s.Length;

      // the idea is by removing from left and right - we meet at some index i
      // so build prefix and suffix arrays
      // left[i] - minimum operation needed with options of removing from left or any ch (2 points)
      // right[i] - minimum operation needed with options of removing from right or any ch (2 points)

      for (int i = 0; i < n; i++)
      {
        if (s[i] == '0')
        {
          left[i] = (i > 0) ? left[i - 1] : 0;
        }
        else
        {
          // either cost is index or prev + 2 points
          left[i] = (i > 0) ? Math.Min(i + 1, left[i - 1] + any) : 1;
        }
      }

      for (int i = n - 1; i >= 0; i--)
      {
        if (s[i] == '0')
        {
          right[i] = (i < n - 1) ? right[i + 1] : 0;
        }
        else
        {
          right[i] = (i < n - 1) ? Math.Min(n - i, right[i + 1] + any) : 1;
        }
      }

      var ans = int.MaxValue;

      // find min at every meeting point
      for (var i = 0; i < n - 1; i++)
      {
        ans = Math.Min(ans, left[i] + right[i + 1]);
      }

      ans = Math.Min(ans, left[n - 1]);
      ans = Math.Min(ans, right[0]);

      return ans;
    }
  }

}
