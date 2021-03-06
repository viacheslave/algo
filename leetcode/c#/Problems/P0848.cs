namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/shifting-letters/
///    Submission: https://leetcode.com/submissions/detail/239748712/
/// </summary>
internal class P0848
{
  public class Solution
  {
    public string ShiftingLetters(string S, int[] shifts)
    {
      for (var i = shifts.Length - 1; i >= 0; i--)
        shifts[i] = (shifts[i] + ((i == shifts.Length - 1) ? 0 : (shifts[i + 1] % 26))) % 26;

      var sb = new StringBuilder(S);

      for (int i = 0; i < shifts.Length; i++)
      {
        sb[i] = (char)(((shifts[i] + ((int)sb[i]) - 97) % 26) + 97);
      }

      return sb.ToString();
    }
  }
}
