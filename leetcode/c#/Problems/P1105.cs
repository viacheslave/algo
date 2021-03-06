namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/filling-bookcase-shelves/
///    Submission: https://leetcode.com/submissions/detail/422358413/
/// </summary>
internal class P1105
{
  public class Solution
  {
    public int MinHeightShelves(int[][] books, int shelf_width)
    {
      var dp = new Dictionary<(int width, int height), int>();

      dp[(books[0][0], books[0][1])] = books[0][1];

      for (var i = 1; i < books.Length; ++i)
      {
        var width = books[i][0];
        var height = books[i][1];

        var temp = new Dictionary<(int width, int height), int>();

        foreach (var entry in dp)
        {
          if (entry.Key.width + width <= shelf_width)
          {
            // place it on the same row
            var sumWidth = entry.Key.width + width;
            var rowHeight = Math.Max(entry.Key.height, height);

            AddOrUpdate(temp, (sumWidth, rowHeight), entry.Value + (rowHeight - entry.Key.height));
          }

          // place it on new row
          AddOrUpdate(temp, (width, height), entry.Value + height);
        }

        dp = temp;
      }

      return dp.Min(c => c.Value);
    }

    private void AddOrUpdate(Dictionary<(int width, int height), int> d, (int sumWidth, int rowHeight) k, int v)
    {
      d[k] = d.ContainsKey(k) ? Math.Min(d[k], v) : v;
    }
  }
}
