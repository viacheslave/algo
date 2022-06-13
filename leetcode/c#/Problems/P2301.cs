namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/match-substring-after-replacement/
///    Submission: https://leetcode.com/submissions/detail/720280285/
/// </summary>
internal class P2301
{
  public class Solution
  {
    public bool MatchReplacement(string s, string sub, char[][] mappings)
    {
      var map = mappings
        .GroupBy(m => m[0])
        .ToDictionary(m => m.Key, m => m.Select(a => a[1]).ToHashSet());

      for (var i = 0; i <= s.Length - sub.Length; i++)
      {
        ReadOnlySpan<char> ss = s[i..(i + sub.Length)];

        if (Matches(ss, sub, map))
        {
          return true;
        }
      }

      return false;
    }

    private static bool Matches(ReadOnlySpan<char> ss, string sub, Dictionary<char, HashSet<char>> map)
    {
      for (var i = 0; i < ss.Length; i++)
      {
        var matches = ss[i] == sub[i] || (map.ContainsKey(sub[i]) && map[sub[i]].Contains(ss[i]));
        if (!matches)
        {
          return false;
        }
      }

      return true;
    }
  }
}
