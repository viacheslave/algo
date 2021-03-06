namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/brick-wall/
///    Submission: https://leetcode.com/submissions/detail/236507952/
/// </summary>
internal class P0554
{
  public class Solution
  {
    public int LeastBricks(IList<IList<int>> wall)
    {
      var rowLength = wall[0].Sum();
      var map = new Dictionary<int, int>();

      foreach (var row in wall)
      {
        var l = 0;
        foreach (var brick in row)
        {
          l += brick;
          if (!map.ContainsKey(l)) map[l] = 0;
          map[l]++;
        }
      }

      var candidate = map.OrderByDescending(_ => _.Value)
          .Where(_ => _.Key != rowLength)
          .FirstOrDefault();

      if (candidate.Key == 0)
        return wall.Count;

      return wall.Count - candidate.Value;
    }
  }
}
