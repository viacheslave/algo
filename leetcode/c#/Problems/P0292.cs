namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/nim-game/
///    Submission: https://leetcode.com/submissions/detail/231799776/
/// </summary>
internal class P0292
{
  public class Solution
  {
    public bool CanWinNim(int n)
    {

      return n % 4 != 0;
    }
  }
}
