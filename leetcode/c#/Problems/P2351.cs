namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/first-letter-to-appear-twice/
///    Submission: https://leetcode.com/submissions/detail/756979419/
/// </summary>
internal class P2351
{
  public class Solution
  {
    public char RepeatedCharacter(string s)
    {
      var set = new HashSet<char>();

      for (int i = 0; i < s.Length; i++)
      {
        if (set.Contains(s[i]))
          return s[i];

        set.Add(s[i]);
      }

      return default;
    }
  }
}
