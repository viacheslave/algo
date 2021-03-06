namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/word-pattern/
///    Submission: https://leetcode.com/submissions/detail/227829632/
/// </summary>
internal class P0290
{
  public class Solution
  {
    public bool WordPattern(string pattern, string str)
    {
      var words = str.Split(' ');

      if (words.Length != pattern.Length)
        return false;

      var map = new Dictionary<char, string>();
      var taken = new HashSet<string>();

      for (var i = 0; i < pattern.Length; i++)
      {
        if (map.ContainsKey(pattern[i]))
        {
          if (map[pattern[i]] != words[i])
            return false;
        }
        else
        {
          if (taken.Contains(words[i]))
            return false;

          map[pattern[i]] = words[i];
          taken.Add(words[i]);
        }
      }

      return true;
    }
  }
}
