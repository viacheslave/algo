namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/query-kth-smallest-trimmed-number/
///    Submission: https://leetcode.com/submissions/detail/750529699/
/// </summary>
internal class P2343
{
  public class Solution
  {
    public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
    {
      // constraints are small

      var len = nums[0].Length;

      var trimmed = new List<List<(string, int)>>();

      var sbs = new List<StringBuilder>();
      for (var i = 0; i < nums.Length; i++)
      {
        sbs.Add(new StringBuilder(nums[i]));
      }

      trimmed.Add(sbs.Select((sb, i) => (sb.ToString(), i)).ToList());

      for (int i = 1; i < len; i++)
      {
        var tr = new List<(string, int)>();

        for (int j = 0; j < sbs.Count; j++)
        {
          sbs[j].Remove(0, 1);
          tr.Add((sbs[j].ToString(), j));
        }

        trimmed.Add(tr);
      }

      trimmed.Reverse();

      foreach (var t in trimmed)
      {
        t.Sort((x, y) =>
        {
          if (x.Item1 == y.Item1)
            return x.Item2.CompareTo(y.Item2);

          return x.Item1.CompareTo(y.Item1);
        });
      }

      var ans = new int[queries.Length];

      for (int i = 0; i < queries.Length; i++)
      {
        var k = queries[i][0];
        var trim = queries[i][1];

        var list = trimmed[trim - 1];
        ans[i] = list[k - 1].Item2;
      }

      return ans;
    }
  }
}
