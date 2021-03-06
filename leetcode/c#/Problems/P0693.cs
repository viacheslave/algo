namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/binary-number-with-alternating-bits/
///    Submission: https://leetcode.com/submissions/detail/230450734/
/// </summary>
internal class P0693
{
  public class Solution
  {
    public bool HasAlternatingBits(int num)
    {
      var power = 0;
      while (num > (int)Math.Pow(2, power))
      {
        power++;
        if (power == 31)
          break;
      }

      var value = num % 2;

      for (var i = 1; i < power; i++)
      {
        num = num >> 1;

        var digit = (num % 2);

        if ((digit ^ value) == 1)
        {
          value = Math.Abs(value - 1);
          continue;
        }

        return false;
      }

      return true;
    }
  }
}
