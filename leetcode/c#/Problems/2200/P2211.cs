namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-collisions-on-a-road/
///    Submission: https://leetcode.com/submissions/detail/676816960/
/// </summary>
internal class P2211
{
  public class Solution
  {
    public int CountCollisions(string directions)
    {
      var ans = 0;

      // prefix sums

      var left = new int[directions.Length + 1];
      var right = new int[directions.Length + 1];

      for (int i = 0; i < directions.Length; i++)
      {
        if (directions[i] != 'L')
          left[i + 1] = left[i] + 1;
        else
          left[i + 1] = left[i];
      }

      for (int i = directions.Length - 1; i >= 0; i--)
      {
        if (directions[i] != 'R')
          right[i] = right[i + 1] + 1;
        else
          right[i] = right[i + 1];
      }

      for (int i = 0; i < directions.Length; i++)
      {
        if (directions[i] == 'S')
          continue;

        if (directions[i] == 'L' && left[i] > 0)
          ans++;

        if (directions[i] == 'R' && right[i + 1] > 0)
          ans++;
      }

      return ans;
    }
  }

}
