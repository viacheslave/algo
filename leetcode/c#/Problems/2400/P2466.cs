namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-ways-to-build-good-strings/
///    Submission: https://leetcode.com/problems/count-ways-to-build-good-strings/submissions/842815696/
/// </summary>
internal class P2466
{
  public class Solution
  {
    public int CountGoodStrings(int low, int high, int zero, int one)
    {
      var arr = new int[high + 1];
      var sum = 0;
      var mod = (int)1e9 + 7;

      arr[zero]++;
      arr[one]++;

      for (int i = 1; i <= high; i++)
      {
        if (i + zero <= high)
        {
          arr[i + zero] += arr[i];
          arr[i + zero] %= mod;
        }

        if (i + one <= high)
        {
          arr[i + one] += arr[i];
          arr[i + one] %= mod;
        }
      }

      for (int i = low; i <= high; i++)
      {
        sum += arr[i];
        sum %= mod;
      }

      return sum;
    }
  }

}
