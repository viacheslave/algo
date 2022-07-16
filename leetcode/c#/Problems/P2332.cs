namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/the-latest-time-to-catch-a-bus/
///    Submission: https://leetcode.com/submissions/detail/743498359/
/// </summary>
internal class P2332
{
  public class Solution
  {
    public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
    {
      Array.Sort(buses);
      Array.Sort(passengers);

      var passengerSet = passengers.ToHashSet();

      var p = 0;

      var last = passengers[0] - 1;

      // simulation

      foreach (var bus in buses)
      {
        for (var i = 0; i < capacity; i++)
        {
          // if we are after the last passenger or next passenger is going with the next bus
          // we can take the last possible time (if not taken)
          if (p == passengers.Length || passengers[p] > bus)
          {
            if (!passengerSet.Contains(bus)) last = bus;
            break;
          }

          // otherwise try take the time one before
          if (p == 0 || passengers[p - 1] != passengers[p] - 1)
          {
            last = passengers[p] - 1;
          }

          p++;
        }
      }

      return last;
    }
  }
}
