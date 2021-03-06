namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/replace-words/
///    Submission: https://leetcode.com/submissions/detail/235022778/
/// </summary>
internal class P0648
{
  public class Solution
  {
    public string ReplaceWords(IList<string> dict, string sentence)
    {
      var words = sentence.Split(' ');

      var newWords = new string[words.Length];

      for (var i = 0; i < words.Length; i++)
      {
        var matched = dict
            .Where(w => words[i].StartsWith(w))
            .OrderBy(_ => _.Length)
            .FirstOrDefault();

        if (matched == null)
          newWords[i] = words[i];
        else
          newWords[i] = matched;
      }

      return string.Join(' ', newWords);
    }
  }
}
