namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/detect-squares/
///    Submission: https://leetcode.com/submissions/detail/557429236/
/// </summary>
internal class P2013
{
  public class DetectSquares
  {
    private readonly Dictionary<(int, int), int> _ps =
      new Dictionary<(int, int), int>();

    public DetectSquares()
    {
    }

    public void Add(int[] point)
    {
      var p = (point[0], point[1]);

      if (_ps.ContainsKey(p))
        _ps[p]++;
      else
        _ps.Add(p, 1);
    }

    public int Count(int[] point)
    {
      var ans = 0;
      var p = (point[0], point[1]);

      foreach (var n in _ps)
      {
        if (n.Key.Item1 == p.Item1 || n.Key.Item2 == p.Item2)
          continue;

        if (Math.Abs(p.Item1 - n.Key.Item1) != Math.Abs(p.Item2 - n.Key.Item2))
          continue;

        if (Math.Abs(p.Item1 - n.Key.Item1) == 0 || Math.Abs(p.Item2 - n.Key.Item2) == 0)
          continue;

        if (_ps.ContainsKey((p.Item1, n.Key.Item2)) && _ps.ContainsKey((n.Key.Item1, p.Item2)))
          ans += _ps[(p.Item1, n.Key.Item2)] * _ps[(n.Key.Item1, p.Item2)] * n.Value;
      }

      return ans;
    }
  }

}
