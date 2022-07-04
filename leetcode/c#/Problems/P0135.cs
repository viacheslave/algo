namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/candy/
///    Submission: https://leetcode.com/submissions/detail/738029613/
/// </summary>
internal class P0135
{
  public class Solution
  {
    public int Candy(int[] ratings)
    {
      var ltr = new int[ratings.Length];
      var rtl = new int[ratings.Length];

      Array.Fill(ltr, 1);
      Array.Fill(rtl, 1);

      for (var i = 1; i < ratings.Length; i++)
      {
        ltr[i] = ratings[i] > ratings[i - 1] ? ltr[i - 1] + 1 : 1;
      }

      for (var i = ratings.Length - 2; i >= 0; i--)
      {
        rtl[i] = ratings[i] > ratings[i + 1] ? rtl[i + 1] + 1 : 1;
      }

      var ans = 0;

      for (int i = 0; i < ratings.Length; i++)
      {
        ans += Math.Max(ltr[i], rtl[i]);
      }

      return ans;
    }
  }
}
