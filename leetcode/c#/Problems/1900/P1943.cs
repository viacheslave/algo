namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/describe-the-painting/
///    Submission: https://leetcode.com/submissions/detail/527634872/
/// </summary>
internal class P1943
{
  public class Solution
  {
    public IList<IList<long>> SplitPainting(int[][] segments)
    {
      var data = new List<(int point, long color, bool addRemove)>();

      foreach (var segment in segments)
      {
        data.Add((segment[0], segment[2], true));
        data.Add((segment[1], segment[2], false));
      }

      data = data.OrderBy(x => x.point).ToList();

      var flow = data
        .GroupBy(el => el.point)
        .Select(g => (g.Key, Color: g.ToList()))
        .OrderBy(i => i.Key)
        .ToList();

      flow.Insert(0, (0, new List<(int point, long color, bool addRemove)>()));

      var point = flow[0].Key;
      var color = flow[0].Color.Select(i => i.addRemove ? i.color : -i.color).Sum();

      var ans = new List<IList<long>>();

      for (var i = 1; i < flow.Count; ++i)
      {
        ans.Add(new List<long> { point, flow[i].Key, color });

        point = flow[i].Key;

        foreach (var c in flow[i].Color)
          color += c.addRemove ? c.color : -c.color;
      }

      return ans
        .Skip(1)
        .Where(i => i[2] != 0)
        .ToList();
    }
  }
}
