namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/range-product-queries-of-powers/
///    Submission: https://leetcode.com/problems/range-product-queries-of-powers/submissions/823835476/
/// </summary>
internal class P2438
{
  public class Solution
  {
    public int[] ProductQueries(int n, int[][] queries)
    {
      var powers = new List<int>();

      var power = 0;
      while (n > 0)
      {
        if (n % 2 == 1)
        {
          powers.Add(power);
        }

        n >>= 1;
        power++;
      }

      var prefixSums = new int[powers.Count + 1];

      for (int i = 0; i < powers.Count; i++)
      {
        prefixSums[i + 1] = prefixSums[i] + powers[i];
      }

      var mod = (int)1e9 + 7;
      var ans = new int[queries.Length];

      var index = 0;
      foreach (var query in queries)
      {
        var sum = prefixSums[query[1] + 1] - prefixSums[query[0]];
        var a = Enumerable.Repeat(2, sum).Aggregate(1,
          (acc, v) => (acc * 2) % mod);

        ans[index++] = a;
      }

      return ans;
    }
  }

}
