namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-impossible-or/
///    Submission: https://leetcode.com/problems/minimum-impossible-or/submissions/1032282337/
/// </summary>
internal class P2568
{
  public class Solution
  {
    public int MinImpossibleOR(int[] nums)
    {
      var set = new HashSet<int>();

      for (int i = 0; i < nums.Length; i++)
      {
        set.Add(nums[i]);
      }

      var power = 0;
      while (power < 32)
      {
        if (set.Contains(1 << power))
        {
          power++;
          continue;
        }

        return 1 << power;
      }

      // never happens
      return 1 << power;
    }
  }
}
