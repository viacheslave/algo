namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/reconstruct-itinerary/
///    Submission: https://leetcode.com/submissions/detail/421736340/
/// </summary>
internal class P0332
{
  public class Solution
  {
    private List<int> _min;

    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
      var current = new List<int>();

      var points = tickets
        .SelectMany(t => new[] { t[0], t[1] })
        .Distinct()
        .OrderBy(x => x)
        .Select((x, i) => (x, i))
        .ToDictionary(c => c.x, c => c.i);

      var pointsRev = points.ToDictionary(x => x.Value, x => x.Key);

      var conn = new int[points.Count, points.Count];

      foreach (var ticket in tickets)
        conn[points[ticket[0]], points[ticket[1]]]++;

      current.Add(points["JFK"]);

      DFS(points, pointsRev, conn, points["JFK"], current, 1, tickets.Count + 1);

      var ans = _min.Select(x => pointsRev[x]).ToList();
      return ans;
    }

    private void DFS(
      Dictionary<string, int> points,
      Dictionary<int, string> pointsRev,
      int[,] conn,
      int start,
      List<int> current,
      int length,
      int expected)
    {
      if (length == expected)
      {
        _min = current.ToList();
        return;
      }

      for (var i = 0; i < points.Count; i++)
      {
        if (conn[start, i] == 0)
          continue;

        if (_min != null && _min[length] < i)
          continue;

        conn[start, i]--;

        current.Add(i);

        DFS(points, pointsRev, conn, i, current, length + 1, expected);

        current.RemoveAt(current.Count - 1);

        conn[start, i]++;
      }
    }
  }
}
