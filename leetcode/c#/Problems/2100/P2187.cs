namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-time-to-complete-trips/
///    Submission: https://leetcode.com/problems/minimum-time-to-complete-trips/submissions/910904017/
/// </summary>
internal class P2187
{
  public class Solution
  {
    public long MinimumTime(int[] time, int totalTrips)
    {
      Array.Sort(time);

      // binary search
      long left = 0L;
      long right = long.MaxValue;

      while (left < right)
      {
        var mid = (left + right) / 2;
        var enoughTime = EnoughTime(time, mid, totalTrips);

        if (enoughTime)
        {
          right = mid;
        }
        else
        {
          left = mid + 1;
        }
      }

      return left;
    }

    private bool EnoughTime(int[] buses, long time, int totalTrips)
    {
      var trips = 0L;

      for (int i = 0; i < buses.Length; i++)
      {
        var tr = time / buses[i];
        if (tr == 0)
          break;

        trips += tr;

        if (trips >= totalTrips)
          return true;
      }

      return trips >= totalTrips;
    }
  }
}
