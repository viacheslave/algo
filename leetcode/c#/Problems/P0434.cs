namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/number-of-segments-in-a-string/
///    Submission: https://leetcode.com/submissions/detail/228894050/
/// </summary>
internal class P0434
{
  public class Solution
  {
    public int CountSegments(string s)
    {
      return s.Split(' ')
          .Where(seg => seg != string.Empty)
          .Count();
    }
  }
}
