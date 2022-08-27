namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-hours-of-training-to-win-a-competition/
///    Submission: https://leetcode.com/submissions/detail/782080516/
/// </summary>
internal class P2383
{
  public class Solution
  {
    public int MinNumberOfHours(int initialEnergy, int initialExperience, int[] energy, int[] experience)
    {
      /*
       energy = [1,4,3,2], 
       experience = [2,6,3,1]
      */

      var exp = 0;
      var needExp = int.MaxValue;

      for (int i = 0; i < experience.Length; i++)
      {
        needExp = Math.Min(needExp, exp - experience[i] - 1);
        exp += experience[i];
      }

      needExp = Math.Abs(needExp);
      needExp -= initialExperience;

      var needEnergy = energy.Sum() + 1;
      needEnergy -= initialEnergy;

      return Math.Max(0, needEnergy) + Math.Max(0, needExp);
    }
  }
}
