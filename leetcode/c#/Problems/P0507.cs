namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/perfect-number/
///    Submission: https://leetcode.com/submissions/detail/230205299/
/// </summary>
internal class P0507
{
  public class Solution
  {
    public bool CheckPerfectNumber(int num)
    {
      if (num < 2)
        return false;

      int sum = 0;

      for (var i = 1; i <= Math.Sqrt(num); i++)
      {
        if (num % i == 0)
        {
          if (num / i == i)
          {
            sum += i;
          }
          else
          {
            sum += i;
            if (num / i != num)
            {
              sum += num / i;
            }
          }
        }
      }

      return sum == num;
    }
  }
}
