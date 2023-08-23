namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/divide-players-into-teams-of-equal-skill/
///    Submission: https://leetcode.com/problems/divide-players-into-teams-of-equal-skill/submissions/854384013/
/// </summary>
internal class P2491
{
  public class Solution
  {
    public long DividePlayers(int[] skill)
    {
      Array.Sort(skill);

      var sums = new List<long>();
      var chem = new List<long>();

      for (int i = 0; i < skill.Length / 2; i++)
      {
        sums.Add(1L * skill[i] + 1L * skill[skill.Length - 1 - i]);
        chem.Add(1L * skill[i] * skill[skill.Length - 1 - i]);
      }

      if (sums.Distinct().Count() != 1)
      {
        return -1;
      }

      return chem.Sum();
    }
  }
}
