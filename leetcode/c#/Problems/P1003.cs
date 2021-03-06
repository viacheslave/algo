namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/check-if-word-is-valid-after-substitutions/
///    Submission: https://leetcode.com/submissions/detail/247310953/
/// </summary>
internal class P1003
{
  public class Solution
  {
    public bool IsValid(string S)
    {
      var abc = "abc";

      while (true)
      {
        var index = S.IndexOf(abc);
        if (index == -1)
          return false;

        S = S.Remove(index, abc.Length);
        if (S.Length == 0)
          return true;
      }
    }
  }
}
