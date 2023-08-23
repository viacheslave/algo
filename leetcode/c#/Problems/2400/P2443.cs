namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/sum-of-number-and-its-reverse/
///    Submission: https://leetcode.com/problems/sum-of-number-and-its-reverse/submissions/823854077/
/// </summary>
internal class P2443
{
  public class Solution
  {
    public bool SumOfNumberAndReverse(int num)
    {
      // brute force

      for (var i = 0; i <= num; i++)
      {
        var reverse = int.Parse(new string(i.ToString().Reverse().ToArray()));

        if (reverse + i == num)
        {
          return true;
        }
      }

      return false;
    }
  }
}
