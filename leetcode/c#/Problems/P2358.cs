namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-number-of-groups-entering-a-competition/
///    Submission: https://leetcode.com/submissions/detail/761677371/
/// </summary>
internal class P2358
{
  public class Solution
  {
    public int MaximumGroups(int[] grades)
    {
      // greedy
      Array.Sort(grades);

      var ans = 0;
      var length = grades.Length;

      for (var i = 1; ; i++)
      {
        length -= i;

        if (length > 0)
        {
          ans++;
        }
        else if (length == 0)
        {
          ans++;
          return ans;
        }
        else
        {
          return ans;
        }
      }
    }
  }
}
