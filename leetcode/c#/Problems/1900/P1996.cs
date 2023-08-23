namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/the-number-of-weak-characters-in-the-game/
///    Submission: https://leetcode.com/submissions/detail/551072964/
/// </summary>
internal class P1996
{
  public class Solution
  {
    public int NumberOfWeakCharacters(int[][] properties)
    {
      var byAttack = properties
        .Select(p => (attack: p[0], defense: p[1]))
        .GroupBy(p => p.attack)
        .OrderBy(g => g.Key)
        .Select(g => (Attack: g.Key, Items: g.Select(a => a.defense).ToList()))
        .ToArray();

      var suffixDefense = new int[byAttack.Length + 1];

      for (var i = byAttack.Length - 1; i >= 1; i--)
        suffixDefense[i] = Math.Max(suffixDefense[i + 1], byAttack[i].Items.Max(f => f));

      var ans = 0;

      for (var i = 0; i < byAttack.Length - 1; i++)
      {
        foreach (var defence in byAttack[i].Items)
        {
          if (defence < suffixDefense[i + 1])
            ans++;
        }
      }

      return ans;
    }
  }
}
