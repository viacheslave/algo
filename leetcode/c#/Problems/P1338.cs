namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/reduce-array-size-to-the-half/
///    Submission: https://leetcode.com/submissions/detail/299626437/
/// </summary>
internal class P1338
{
  public class Solution
  {
    public int MinSetSize(int[] arr)
    {
      var counts = arr.GroupBy(a => a).Select(a => a.Count()).OrderByDescending(a => a).ToList();

      var total = 0;
      var ans = 0;

      for (int i = 0; i < counts.Count; i++)
      {
        total += counts[i];
        ans++;

        if (total >= arr.Length / 2)
          break;
      }

      return ans;
    }
  }
}
