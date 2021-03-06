namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/generate-a-string-with-characters-that-have-odd-counts/
///    Submission: https://leetcode.com/submissions/detail/310652293/
/// </summary>
internal class P1374
{
  public class Solution
  {
    public string GenerateTheString(int n)
    {
      var code = 97;
      var sb = new StringBuilder();

      while (n > 0)
      {
        var count = Math.Min(n % 2 == 0 ? n - 1 : n, 25);
        sb.Append((char)code, count);
        code++;
        n -= count;
      }

      return sb.ToString();
    }
  }
}
