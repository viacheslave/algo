namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/valid-perfect-square/
///    Submission: https://leetcode.com/submissions/detail/226159452/
/// </summary>
internal class P0367
{
  public class Solution
  {
    public bool IsPerfectSquare(int num)
    {
      if (num == 0)
        return true;

      if (num == 1)
        return true;

      var i = 2;

      while (true)
      {
        var s = i * i;

        if (s < 0)
          return false;

        if (s == num)
          return true;

        i++;
      }
    }
  }
}
