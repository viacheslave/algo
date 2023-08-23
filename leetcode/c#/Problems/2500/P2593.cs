namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/find-score-of-an-array-after-marking-all-elements/
///    Submission: https://leetcode.com/problems/find-score-of-an-array-after-marking-all-elements/submissions/921743068/
/// </summary>
internal class P2593
{
  public class Solution
  {
    public long FindScore(int[] nums)
    {
      var ans = 0L;

      var arr = nums.Select((n, i) => (n, i))
        .OrderBy(x => x.n)
        .ThenBy(x => x.i)
        .ToArray();

      var marked = new int[nums.Length];

      for (int i = 0; i < nums.Length; i++)
      {
        var el = arr[i];

        if (marked[el.i] == 1)
          continue;

        ans += el.n;

        marked[el.i] = 1;
        if (el.i > 0) marked[el.i - 1] = 1;
        if (el.i < nums.Length - 1) marked[el.i + 1] = 1;
      }

      return ans;
    }
  }
}
