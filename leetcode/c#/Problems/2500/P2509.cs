namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/cycle-length-queries-in-a-tree/
///    Submission: https://leetcode.com/problems/cycle-length-queries-in-a-tree/submissions/861800668/
/// </summary>
internal class P2509
{
  public class Solution
  {
    public int[] CycleLengthQueries(int n, int[][] queries)
    {
      var ans = new int[queries.Length];

      for (int i = 0; i < queries.Length; i++)
      {
        var a = queries[i][0];
        var b = queries[i][1];

        var astr = Convert.ToString(a, 2).PadLeft(31, '0');
        var bstr = Convert.ToString(b, 2).PadLeft(31, '0');

        var common = GetCommonNode(astr, bstr);

        var al = GetLength(astr, common);
        var bl = GetLength(bstr, common);

        ans[i] = al + bl + 1;
      }

      return ans;
    }

    private int GetLength(string a, string b)
    {
      var i = a.IndexOf('1');
      var j = b.IndexOf('1');

      return Math.Abs(i - j);
    }

    private string GetCommonNode(string a, string b)
    {
      var i = a.IndexOf('1');
      var j = b.IndexOf('1');

      var sb = new StringBuilder();

      while (i < a.Length && j < b.Length)
      {
        if (a[i] == b[j])
        {
          sb.Append(a[i]);
          i++; j++;
          continue;
        }

        break;
      }

      return sb.ToString().PadLeft(31, '0');
    }
  }
}
