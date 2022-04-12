namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-number-of-operations-to-convert-time/
///    Submission: https://leetcode.com/submissions/detail/677751457/
/// </summary>
internal class P2224
{
  public class Solution
  {
    public int ConvertTime(string current, string correct)
    {
      var currentMins = int.Parse(current[..2]) * 60 + int.Parse(current[3..]);
      var correctMins = int.Parse(correct[..2]) * 60 + int.Parse(correct[3..]);

      // greedy
      var diff = correctMins - currentMins;
      var ans = 0;

      while (diff != 0)
      {
        if (diff >= 60)
        {
          diff -= 60;
        }
        else if (diff >= 15)
        {
          diff -= 15;
        }
        else if (diff >= 5)
        {
          diff -= 5;
        }
        else
        {
          diff -= 1;
        }
        ans++;
      }

      return ans;
    }
  }
}
