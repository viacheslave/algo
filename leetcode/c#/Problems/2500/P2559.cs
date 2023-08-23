namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-vowel-strings-in-ranges
///    Submission: https://leetcode.com/problems/count-vowel-strings-in-ranges/submissions/917498710/
/// </summary>
internal class P2559
{
  public class Solution
  {
    public int[] VowelStrings(string[] words, int[][] queries)
    {
      var prefixSum = new int[words.Length + 1];
      var vowels = new HashSet<char> { 'a', 'o', 'e', 'i', 'u' };

      for (int i = 0; i < words.Length; i++)
      {
        prefixSum[i + 1] = prefixSum[i] + (Fits(words[i], vowels) ? 1 : 0);
      }

      var ans = new int[queries.Length];

      for (int i = 0; i < queries.Length; i++)
      {
        ans[i] = prefixSum[queries[i][1] + 1] - prefixSum[queries[i][0]];
      }

      return ans;
    }

    private bool Fits(string word, ISet<char> vowels) => vowels.Contains(word[0]) && vowels.Contains(word[^1]);
  }
}
