namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-string-chain/
///    Submission: https://leetcode.com/submissions/detail/722834159/
/// </summary>
internal class P1048
{
  public class Solution
  {
    public int LongestStrChain(string[] words)
    {
      var dp = new int[words.Length];
      Array.Fill(dp, 1);

      var wordList = words.OrderByDescending(w => w.Length).ToList();

      var maps = wordList
        .Select((word, index) => (word, index))
        .GroupBy(g => g.word.Length)
        .ToDictionary(g => g.Key, g => g.OrderBy(i => i.index).ToList());

      for (var i = 0; i < wordList.Count; i++)
      {
        var word = wordList[i];

        var left = maps.GetValueOrDefault(word.Length + 1);
        if (left is not null)
        {
          foreach (var l in left)
          {
            if (Matches(l.word, word))
            {
              dp[i] = Math.Max(dp[i], dp[l.index] + 1);
            }
          }
        }
      }

      return dp.Max();
    }

    private bool Matches(string left, string word)
    {
      var l = 0;
      var hit = false;

      for (var w = 0; w < word.Length; w++)
      {
        if (word[w] == left[l])
        {
          l++;
          continue;
        }

        if (hit)
        {
          return false;
        }

        w--;
        l++;
        hit = true;
      }

      return true;
    }
  }
}
