namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/egg-drop-with-2-eggs-and-n-floors/
///    Submission: https://leetcode.com/submissions/detail/526477184/
/// </summary>
internal class P1884
{
  public class Solution
  {
    public int TwoEggDrop(int n)
    {
      var ans = 0;
      var inc = 1;

      while (n > 0)
      {
        n -= inc;
        ans++;
        inc++;
      }

      return ans;
    }
  }
}
