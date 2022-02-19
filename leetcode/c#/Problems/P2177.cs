namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-three-consecutive-integers-that-sum-to-a-given-number/
///    Submission: https://leetcode.com/submissions/detail/644554188/
/// </summary>
internal class P2177
{
  public class Solution
  {
    public long[] SumOfThree(long num)
    {
      if (num == 0)
      {
        return new long[] { -1, 0, 1 };
      }

      if (num % 3 != 0)
        return new long[0];

      return new long[] { num / 3 - 1, num / 3, num / 3 + 1 };
    }
  }
}
