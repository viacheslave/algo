namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-number-of-operations-to-make-array-empty/
///    Submission: https://leetcode.com/problems/minimum-number-of-operations-to-make-array-empty/submissions/1064830658/
/// </summary>
internal class P2870
{
  public class Solution
  {
    public int MinOperations(int[] nums)
    {
      var groups = nums.GroupBy(c => c)
        .ToDictionary(x => x.Key, x => x.Count());

      if (groups.Any(x => x.Value == 1))
      {
        return -1;
      }

      var ans = 0;

      foreach (var ek in groups)
      {
        if (ek.Value % 3 == 0)
        {
          ans += ek.Value / 3;
        }
        else if (ek.Value % 3 == 1)
        {
          ans += (ek.Value - 4) / 3 + 2;
        }
        else
        {
          ans += (ek.Value - 2) / 3 + 1;
        }
      }

      return ans;
    }
  }
}
