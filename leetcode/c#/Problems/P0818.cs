namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/race-car/
///    Submission: https://leetcode.com/submissions/detail/587477010/
/// </summary>
internal class P0818
{
  public class Solution
  {
    public int Racecar(int target)
    {
      // based on BFS
      // plus artificial limit

      var dp = new Dictionary<(int position, int speed), int>
      {
        [(0, 1)] = 0
      };

      while (true)
      {
        var next = new Dictionary<(int position, int speed), int>();
        foreach (var item in dp)
        {
          if (item.Key.position == target)
            return item.Value;

          var position = item.Key.position;
          var speed = item.Key.speed;

          // allow artificial limit to avoid
          // Tests took to long
          if (Math.Abs(position + speed) >= 100_000)
            continue;

          // A
          var a_speed = speed * 2;
          var a_key = (position + speed, a_speed);

          next[a_key] = !next.ContainsKey(a_key)
            ? item.Value + 1
            : Math.Min(next[a_key], item.Value + 1);

          // R
          var r_speed = speed > 0 ? -1 : 1;
          var r_key = (position, r_speed);

          next[r_key] = !next.ContainsKey(r_key)
            ? item.Value + 1
            : Math.Min(next[r_key], item.Value + 1);
        }

        dp = next;
      }

      return -1;
    }
  }
}
