namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences/submissions/
///    Submission: https://leetcode.com/submissions/detail/527650657/
/// </summary>
internal class P1941
{
  public class Solution
  {
    public bool AreOccurrencesEqual(string s)
    {
      return s.GroupBy(ch => ch)
          .Select(g => g.Count())
          .Distinct()
          .Count() == 1;
    }
  }
}
