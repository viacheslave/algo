namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/shortest-and-lexicographically-smallest-beautiful-string/
///    Submission: https://leetcode.com/problems/shortest-and-lexicographically-smallest-beautiful-string/submissions/1076924007/
/// </summary>
internal class P2904
{
  public class Solution {
    public string ShortestBeautifulSubstring(string s, int k) {
      var ones = s.Select((c, i) => (c, i))
          .Where(c => c.c == '1')
          .ToList();

      if (ones.Count < k)
        return string.Empty;

      int min = int.MaxValue;
      string sub = "";

      for (var i = 0; i < ones.Count - k + 1; i++) {
        var from = ones[i].i;
        var to = ones[i + k - 1].i;

        if (to - from < min) {
          min = to - from;
          sub = s.Substring(from, to - from + 1);
        }
        else if (to - from == min && s.Substring(from, to - from + 1).CompareTo(sub) < 0) {
          min = to - from;
          sub = s.Substring(from, to - from + 1);
        }
      }
      return sub;
    }
  }
}
