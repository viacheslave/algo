namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sum-of-square-numbers/
///    Submission: https://leetcode.com/submissions/detail/231083946/
/// </summary>
internal class P0633
{
  public class Solution
  {
    public bool JudgeSquareSum(int c)
    {
      var sqs = new HashSet<int>() { 0 };

      var current = 1;
      var addition = 3;

      while (current <= c)
      {
        sqs.Add(current);

        if (c - addition < current)
          break;

        current += addition;
        addition += 2;
      }


      foreach (var sq in sqs)
      {
        if (sqs.Contains(c - sq))
          return true;
      }

      return false;
    }
  }
}
