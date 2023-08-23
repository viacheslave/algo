namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-points-in-an-archery-competition/
///    Submission: https://leetcode.com/submissions/detail/719746180/
/// </summary>
internal class P2212
{
  public class Solution
  {
    public int[] MaximumBobPoints(int numArrows, int[] aliceArrows)
    {
      var bob = new int[12];

      for (var i = 0; i < 12; i++)
      {
        bob[i] = aliceArrows[i] + 1;
      }

      // 2^12 cases

      var sum = 0;
      var arr = new int[12];

      for (var i = 1; i < 4096; i++)
      {
        var a = i;

        var ans = new int[12];
        var sumPoints = 0;
        var sumArrows = 0;

        for (var j = 12 - 1; j >= 0; j--)
        {
          if (a % 2 == 1)
          {
            ans[j] = bob[j];
            sumPoints += j;
            sumArrows += bob[j];
          }
          a >>= 1;
        }

        if (sumArrows > numArrows)
          continue;

        if (sumPoints > sum)
        {
          sum = sumPoints;
          arr = ans;

          // fix missing points
          if (sumArrows < numArrows)
          {
            arr[0] += numArrows - sumArrows;
          }
        }
      }

      return arr;
    }
  }
}
