namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/excel-sheet-column-title/
///    Submission: https://leetcode.com/submissions/detail/228441770/
/// </summary>
internal class P0168
{
  public class Solution
  {
    public string ConvertToTitle(int n)
    {
      int power = 26;
      var sb = new StringBuilder();

      while (n > 0)
      {
        var digit = (n - 1) % power;

        var ch = (char)(digit + 65);
        sb.Insert(0, ch);

        n = (n - digit) / power;
      }

      return sb.ToString();
    }
  }
}
