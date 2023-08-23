namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-number-of-rectangles-containing-each-point/
///    Submission: https://leetcode.com/submissions/detail/687750559/
/// </summary>
internal class P2250
{
  public class Solution
  {
    public int[] CountRectangles(int[][] rectangles, int[][] points)
    {
      var gr = rectangles
        .GroupBy(x => x[1])
        .ToDictionary(x => x.Key, x => x.OrderBy(i => i[0]).Select(i => i[0]).ToList());

      var rh = new SortedDictionary<int, List<int>>(gr);
      var rhKeys = rh.Keys.ToList();

      var ans = new int[points.Length];

      for (var i = 0; i < points.Length; i++)
      {
        var pw = points[i][0];
        var ph = points[i][1];
        var pa = 0;

        for (var hi = rhKeys.Count - 1; hi >= 0; hi--)
        {
          var h = rhKeys[hi];
          if (h < ph)
          {
            break;
          }

          var values = gr[h];

          var bs = BinarySearch(values, pw);
          pa += bs;
        }

        ans[i] = pa;
      }

      return ans;
    }

    private int BinarySearch(List<int> values, int pw)
    {
      if (pw > values[^1])
        return 0;

      if (pw < values[0])
        return values.Count;

      var left = 0;
      var right = values.Count - 1;

      while (true)
      {
        if (right - left < 2)
        {
          if (pw <= values[left])
            return values.Count - left;
          return values.Count - right;
        }

        var mid = (left + right) >> 1;
        if (pw <= values[mid])
        {
          right = mid;
        }
        else
        {
          left = mid;
        }
      }

    }
  }
}
