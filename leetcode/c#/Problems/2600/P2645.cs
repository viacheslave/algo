namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-additions-to-make-valid-string/
///    Submission: https://leetcode.com/problems/minimum-additions-to-make-valid-string/submissions/1028988103/
/// </summary>
internal class P2645
{
  public class Solution
  {
    public int AddMinimum(string word)
    {
      var sb = new StringBuilder();

      var inserts = new List<string>();

      for (int i = 0; i < word.Length - 1; i++)
      {
        var pair = (word[i], word[i + 1]);
        var insert = pair switch
        {
          ('a', 'a') => "bc",
          ('a', 'b') => "",
          ('a', 'c') => "b",

          ('b', 'a') => "c",
          ('b', 'b') => "ca",
          ('b', 'c') => "",

          ('c', 'a') => "",
          ('c', 'b') => "a",
          ('c', 'c') => "ab",
        };

        inserts.Add(insert);
      }

      var prefix = word[0] switch
      {
        'a' => "",
        'b' => "a",
        'c' => "ab"
      };

      var suffix = word[^1] switch
      {
        'a' => "bc",
        'b' => "c",
        'c' => ""
      };

      inserts.Add(prefix);
      inserts.Add(suffix);

      return inserts.Sum(x => x.Length);
    }
  }
}
