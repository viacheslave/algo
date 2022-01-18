namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/reverse-string/
///    Submission: https://leetcode.com/submissions/detail/227558283/
/// </summary>
internal class P0344
{
  public class Solution
  {
    public void ReverseString(char[] s)
    {
      for (var i = 0; i < s.Length / 2; i++)
      {
        var temp = s[i];
        s[i] = s[s.Length - 1 - i];
        s[s.Length - 1 - i] = temp;
      }
    }
  }
}
