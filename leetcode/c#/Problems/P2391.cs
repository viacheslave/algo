namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-amount-of-time-to-collect-garbage/
///    Submission: https://leetcode.com/submissions/detail/788112943/
/// </summary>
internal class P2391
{
  public class Solution
  {
    public int GarbageCollection(string[] garbage, int[] travel)
    {
      var score = 0;

      var paper = -1;
      var metal = -1;
      var glass = -1;

      for (int i = 0; i < garbage.Length; i++)
      {
        score += garbage[i].Length;

        if (i != garbage.Length - 1)
          score += travel[i] * 3;

        if (garbage[i].Contains('P'))
          paper = i;

        if (garbage[i].Contains('M'))
          metal = i;

        if (garbage[i].Contains('G'))
          glass = i;
      }

      score -= travel.TakeLast(garbage.Length - 1 - paper).Sum();
      score -= travel.TakeLast(garbage.Length - 1 - metal).Sum();
      score -= travel.TakeLast(garbage.Length - 1 - glass).Sum();

      return score;
    }
  }
}
