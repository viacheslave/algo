namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-if-numbers-are-ascending-in-a-sentence/
///    Submission: https://leetcode.com/submissions/detail/583493764/
/// </summary>
internal class P2042
{
  public class Solution
  {
    public bool AreNumbersAscending(string s)
    {
      var tokens = s.Split(new char[] { ' ' });
      var numbers = new List<int>();

      foreach (var token in tokens)
      {
        if (int.TryParse(token, out var i))
          numbers.Add(i);
      }

      for (var i = 1; i < numbers.Count; i++)
        if (numbers[i] <= numbers[i - 1])
          return false;

      return true;
    }
  }
}
