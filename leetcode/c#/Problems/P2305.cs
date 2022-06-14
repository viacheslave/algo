namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/fair-distribution-of-cookies/
///    Submission: https://leetcode.com/submissions/detail/722176546/
/// </summary>
internal class P2305
{
  public class Solution
  {
    public int DistributeCookies(int[] cookies, int k)
    {
      var distribution = new int[k];

      // recursive
      var ans = Distribute(cookies, 0, distribution, k);
      return ans;
    }

    private int Distribute(int[] cookies, int cookieIndex, int[] distribution, int k)
    {
      if (cookieIndex == cookies.Length)
      {
        if (distribution.All(x => x > 0))
          return distribution.Max();

        return int.MaxValue;
      }

      var min = int.MaxValue;

      for (var i = 0; i < k; i++)
      {
        distribution[i] += cookies[cookieIndex];

        var value = Distribute(cookies, cookieIndex + 1, distribution, k);
        min = Math.Min(min, value);

        distribution[i] -= cookies[cookieIndex];
      }

      return min;
    }
  }
}
