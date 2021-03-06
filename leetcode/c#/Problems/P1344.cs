namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/angle-between-hands-of-a-clock/
///    Submission: https://leetcode.com/submissions/detail/301638736/
/// </summary>
internal class P1344
{
  public class Solution
  {
    public double AngleClock(int hour, int minutes)
    {
      if (hour == 12)
        hour = 0;

      var angleMinute = minutes * 6;
      var angleHour = 30 * hour + (minutes / 2d);

      var ans = Math.Abs(angleHour - angleMinute);
      if (360 - ans < ans)
        ans = 360 - ans;
      return ans;
    }
  }
}
