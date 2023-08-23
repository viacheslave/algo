namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-valid-clock-times/
///    Submission: https://leetcode.com/problems/number-of-valid-clock-times/submissions/823850320/
/// </summary>
internal class P2437
{
  public class Solution
  {
    public int CountTime(string time)
    {
      var t = new TimeOnly(0, 0);
      var ans = 0;

      while (true)
      {
        var str = t.ToString("HH:mm");

        if (
          (time[0] == str[0] || time[0] == '?') &&
          (time[1] == str[1] || time[1] == '?') &&
          (time[3] == str[3] || time[3] == '?') &&
          (time[4] == str[4] || time[4] == '?')
        )
        {
          ans++;
        }

        if (t == new TimeOnly(23, 59))
          break;

        t = t.AddMinutes(1);
      }

      return ans;
    }
  }
}
