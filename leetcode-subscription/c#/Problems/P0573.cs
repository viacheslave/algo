using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/squirrel-simulation/
  ///    Submission: https://leetcode.com/submissions/detail/450720577/
  ///    Square
  /// </summary>
  internal class P0573
  {
    public class Solution
    {
      public int MinDistance(int height, int width, int[] tree, int[] squirrel, int[][] nuts)
      {
        var total = 0;

        for (var i = 0; i < nuts.Length; i++)
        {
          var dist = Math.Abs(nuts[i][0] - tree[0]) + Math.Abs(nuts[i][1] - tree[1]);
          total += dist * 2;
        }

        var ans = int.MaxValue;

        for (var i = 0; i < nuts.Length; i++)
        {
          var distSq = Math.Abs(nuts[i][0] - squirrel[0]) + Math.Abs(nuts[i][1] - squirrel[1]);
          var distNut = Math.Abs(nuts[i][0] - tree[0]) + Math.Abs(nuts[i][1] - tree[1]);

          ans = Math.Min(ans, total - distNut * 2 + distNut + distSq);
        }

        return ans;
      }
    }
  }
}
