namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-palindrome-by-concatenating-two-letter-words/
///    Submission: https://leetcode.com/submissions/detail/616122238/
/// </summary>
internal class P2131
{
  public class Solution
  {
    public int LongestPalindrome(string[] words)
    {
      var sameMap = words.Where(x => x[0] == x[1]).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
      var sameChCount = 0;

      if (sameMap.Count > 0)
      {
        var counts = sameMap.Values.ToList();
        foreach (var c in counts)
        {
          if (c % 2 == 1)
            sameChCount += (c - 1);
          else
            sameChCount += c;
        }

        if (counts.Any(x => x % 2 == 1))
          sameChCount++;
      }

      var diffMap = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
      var diffChCount = 0;

      foreach (var e in diffMap)
      {
        if (e.Key[0] == e.Key[1])
          continue;

        var reverse = e.Key[1].ToString() + e.Key[0].ToString();

        if (diffMap.ContainsKey(reverse))
        {
          var min = Math.Min(e.Value, diffMap[reverse]);
          var pairs = min + min;

          diffChCount += pairs;
        }
      }

      return 2 * (sameChCount + diffChCount / 2);
    }
  }


}
