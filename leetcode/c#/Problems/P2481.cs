namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-cuts-to-divide-a-circle/
///    Submission: https://leetcode.com/problems/minimum-cuts-to-divide-a-circle/submissions/850627203/
/// </summary>
internal class P2481
{
  public class Solution
  {
    public int NumberOfCuts(int n)
    {
      if (n == 1)
        return 0;
      return n % 2 == 0 ? n / 2 : n;
    }
  }
}
