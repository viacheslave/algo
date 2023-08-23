namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/substring-xor-queries/
///    Submission: https://leetcode.com/problems/substring-xor-queries/submissions/896601606/
/// </summary>
internal class P2564
{
  public class Solution
  {
    public int[][] SubstringXorQueries(string s, int[][] queries)
    {
      var dict = new Dictionary<int, (int, int)>();

      // preprocessing
      for (int i = 0; i < s.Length; i++)
      {
        var num = 0;
        for (int j = i; j < i + 30; j++)
        {
          if (j == s.Length)
            break;

          num <<= 1;
          num += s[j] == '1' ? 1 : 0;

          if (dict.ContainsKey(num) && dict[num].Item2 - dict[num].Item1 <= j - i)
            continue;

          dict[num] = (i, j);
        }
      }

      // ans
      var ans = new int[queries.Length][];

      for (int i = 0; i < queries.Length; i++)
      {
        var target = queries[i][0] ^ queries[i][1];

        if (dict.ContainsKey(target))
        {
          ans[i] = new[] { dict[target].Item1, dict[target].Item2 };
        }
        else
        {
          ans[i] = new[] { -1, -1 };
        }
      }

      return ans;
    }
  }

}
