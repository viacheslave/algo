namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-the-divisibility-array-of-a-string/
///    Submission: https://leetcode.com/problems/find-the-divisibility-array-of-a-string/submissions/913228487/
/// </summary>
internal class P2575
{
  public class Solution
  {
    public int[] DivisibilityArray(string word, int m)
    {
      var ans = new int[word.Length];

      long mod = 0;
      for (int i = 0; i < word.Length; i++)
      {
        mod = (int.Parse(word[i].ToString()) + mod * 10) % m;
        ans[i] = mod == 0 ? 1 : 0;
      }

      return ans;
    }
  }
}
