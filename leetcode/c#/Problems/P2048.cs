namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/next-greater-numerically-balanced-number/
///    Submission: https://leetcode.com/submissions/detail/580941948/
/// </summary>
internal class P2048
{
  public class Solution
  {
    public int NextBeautifulNumber(int n)
    {
      if (n == 0)
        return 1;

      if (n >= 666666)
        return 1224444;

      var o1 = Generate(1, new int[][] { new int[] { 1 } });
      var o2 = Generate(2, new int[][] { new int[] { 2 } });
      var o3 = Generate(3, new int[][] { new int[] { 1, 2 }, new int[] { 3 } });
      var o4 = Generate(4, new int[][] { new int[] { 1, 3 }, new int[] { 4 } });
      var o5 = Generate(5, new int[][] { new int[] { 2, 3 }, new int[] { 1, 4 }, new int[] { 5 } });
      var o6 = Generate(6, new int[][] { new int[] { 1, 2, 3 }, new int[] { 2, 4 }, new int[] { 1, 5 }, new int[] { 6 } });

      var arr = o1.Concat(o2).Concat(o3).Concat(o4).Concat(o5).Concat(o6)
        .OrderBy(x => x).ToArray();

      for (var i = 0; i < arr.Length - 1; i++)
      {
        if (arr[i] <= n && n < arr[i + 1])
          return arr[i + 1];
      }

      return 0;
    }

    private IEnumerable<int> Generate(int count, int[][] vs)
    {
      var res = new List<IEnumerable<int>>();

      foreach (var v in vs)
        res.Add(Generate(count, v));

      return res.SelectMany(x => x).ToList();
    }

    private IEnumerable<int> Generate(int count, int[] v)
    {
      var res = new List<List<int>>();

      var allowed = new int[6];
      foreach (var vi in v)
        allowed[vi - 1] = vi;

      var current = new List<int>();

      Generate(count, 0, allowed, current, res);

      return res.Select(x => int.Parse(string.Concat(x))).ToList();
    }

    private void Generate(int count, int index, int[] allowed, List<int> current, List<List<int>> res)
    {
      if (index == count)
      {
        res.Add(current.ToList());
        return;
      }

      for (var i = 0; i < allowed.Length; i++)
      {
        if (allowed[i] == 0)
          continue;

        allowed[i]--;

        current.Add(i + 1);

        Generate(count, index + 1, allowed, current, res);

        current.RemoveAt(current.Count - 1);

        allowed[i]++;
      }
    }
  }
}
