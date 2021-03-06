namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/climbing-stairs/
///    Submission: https://leetcode.com/submissions/detail/226898975/
/// </summary>
internal class P0070
{
  public class Solution
  {
    Dictionary<int, int> fib = new Dictionary<int, int>()
    {
        {1, 1},
        {2, 2},
        {3, 3}
    };

    public int ClimbStairs(int n)
    {

      for (var i = 4; i <= n; i++)
      {
        fib[i] = fib[i - 1] + fib[i - 2];
      }


      return fib[n];
    }
  }
}
