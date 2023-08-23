namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/most-beautiful-item-for-each-query/
///    Submission: https://leetcode.com/submissions/detail/586579059/
/// </summary>
internal class P2070
{
  public class Solution
  {
    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
      // gready
      var goods = items
        .Select(x => (price: x[0], beauty: x[1]))
        .OrderBy(x => x.price)
        .ThenBy(x => x.beauty)
        .ToList();

      var prefixMax = new int[items.Length + 1];
      for (int i = 0; i < goods.Count; i++)
        prefixMax[i + 1] = Math.Max(prefixMax[i], goods[i].beauty);

      var ans = new int[queries.Length];

      for (int i = 0; i < queries.Length; i++)
      {
        var query = queries[i];
        if (query < goods[0].price)
        {
          ans[i] = 0;
          continue;
        }

        var from = 0;
        var to = goods.Count - 1;

        // binary search
        while (true)
        {
          if (to - from < 2)
          {
            ans[i] = goods[to].price <= query
              ? prefixMax[to + 1]
              : prefixMax[from + 1];

            break;
          }

          var mid = (from + to) >> 1;
          if (goods[mid].price > query)
            to = mid;
          else
            from = mid;
        }
      }

      return ans;
    }
  }
}
