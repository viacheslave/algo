namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/determine-if-two-events-have-conflict/
///    Submission: https://leetcode.com/problems/determine-if-two-events-have-conflict/submissions/830121239/
/// </summary>
internal class P2446
{
  public class Solution
  {
    public bool HaveConflict(string[] event1, string[] event2)
    {
      var s1 = TimeOnly.ParseExact(event1[0], "HH:mm");
      var e1 = TimeOnly.ParseExact(event1[1], "HH:mm");
      var s2 = TimeOnly.ParseExact(event2[0], "HH:mm");
      var e2 = TimeOnly.ParseExact(event2[1], "HH:mm");

      return (s1 <= s2 && e1 >= s2) || (s2 <= s1 && e2 >= s1);
    }
  }
}
