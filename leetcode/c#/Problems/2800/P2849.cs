namespace LeetCode.Naive.Problems;
/// <summary>
///    Problem: https://leetcode.com/problems/determine-if-a-cell-is-reachable-at-a-given-time/
///    Submission: https://leetcode.com/problems/determine-if-a-cell-is-reachable-at-a-given-time/submissions/1048570501/
/// </summary>
internal class P2849
{
  public class Solution
  {
    public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
    {
      var dx = Math.Abs(sx - fx);
      var dy = Math.Abs(sy - fy);
      var minTime = Math.Max(dx, dy);

      if (dx == dy && dx == 0 && t == 1)
        return false;

      return t - minTime >= 0;
    }
  }
}
