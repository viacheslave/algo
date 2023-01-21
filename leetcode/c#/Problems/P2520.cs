namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/count-the-digits-that-divide-a-number/
///    Submission: https://leetcode.com/problems/count-the-digits-that-divide-a-number/submissions/873249987/
/// </summary>
internal class P2520
{
  public class Solution
  {
    public int CountDigits(int num)
    {
      return num.ToString()
        .Select(ch => int.Parse(ch.ToString()))
        .Count(ch => num % ch == 0);
    }
  }
}
