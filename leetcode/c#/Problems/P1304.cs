namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero/
///    Submission: https://leetcode.com/submissions/detail/289433999/
/// </summary>
internal class P1304
{
  public class Solution
  {
    public int[] SumZero(int n)
    {
      if (n == 1)
        return new int[] { 0 };
      if (n == 2)
        return new int[] { 1, -1 };

      var en = Enumerable.Range(0, n - 1).ToList();
      en.Add((-1) * en.Sum());

      return en.ToArray();
    }
  }
}
