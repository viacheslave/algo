namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-players-with-zero-or-one-losses/
///    Submission: https://leetcode.com/submissions/detail/672870543/
/// </summary>
internal class P2225
{
  public class Solution
  {
    public IList<IList<int>> FindWinners(int[][] matches)
    {
      var players = matches.SelectMany(x => new[] { x[0], x[1] }).ToHashSet();
      var stats = players.ToDictionary(x => x, _ => 0);

      foreach (var match in matches)
      {
        stats[match[1]]++;
      }

      var noloses = stats.Where(x => x.Value == 0).Select(x => x.Key).OrderBy(x => x).ToArray();
      var oneloss = stats.Where(x => x.Value == 1).Select(x => x.Key).OrderBy(x => x).ToArray();

      return new List<IList<int>> { noloses, oneloss };
    }
  }
}
