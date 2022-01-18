namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/random-pick-with-blacklist/
///    Submission: https://leetcode.com/submissions/detail/586493954/
/// </summary>
internal class P0710
{
  public class Solution
  {
    (int from, int to, int min, int max)[] _prefixSum;
    Random _rnd = new Random();

    public Solution(int n, int[] blacklist)
    {
      Array.Sort(blacklist);

      var intervals = new List<(int, int)>();

      var from = 0;
      foreach (var b in blacklist)
      {
        var to = b - 1;
        if (to >= from)
          intervals.Add((from, to));

        from = b + 1;
      }

      if (n - 1 >= from)
        intervals.Add((from, n - 1));

      _prefixSum = new (int from, int to, int min, int max)[intervals.Count];

      for (var i = 0; i < intervals.Count; i++)
      {
        if (i == 0)
          _prefixSum[i] = (intervals[0].Item1, intervals[0].Item2,
            0, intervals[0].Item2 - intervals[0].Item1);
        else
          _prefixSum[i] = (intervals[i].Item1, intervals[i].Item2,
            _prefixSum[i - 1].max + 1,
            _prefixSum[i - 1].max + intervals[i].Item2 - intervals[i].Item1 + 1);
      }
    }

    public int Pick()
    {
      var rnd = _rnd.Next(0, _prefixSum[^1].max + 1);

      (int from, int to, int min, int max) interval;

      var from = 0;
      var to = _prefixSum.Length - 1;

      // binary search
      while (true)
      {
        if (to - from < 2)
        {
          var i = _prefixSum[from];
          if (i.min <= rnd && rnd <= i.max)
          {
            interval = i; break;
          }

          i = _prefixSum[to];
          if (i.min <= rnd && rnd <= i.max)
          {
            interval = i; break;
          }
        }

        var mid = (from + to) >> 1;
        var v = _prefixSum[mid];

        if (v.min <= rnd && rnd <= v.max)
        {
          interval = v; break;
        }

        if (rnd < v.min)
          to = mid;
        else
          from = mid;
      }

      return interval.from + rnd - interval.min;
    }
  }
}
