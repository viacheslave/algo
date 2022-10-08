namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-common-factors/
///    Submission: https://leetcode.com/problems/number-of-common-factors/submissions/816440727/
/// </summary>
internal class P2427
{
  public class Solution
  {
    public int CommonFactors(int a, int b)
    {
      var ans = 0;

      for (int i = 1; i <= 1000; i++)
      {
        if (a % i == 0 && b % i == 0)
        {
          ans++;
        }
      }

      return ans;
    }
  }

}
