namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/longest-valid-parentheses/
///    Submission: https://leetcode.com/submissions/detail/706227572/
/// </summary>
internal class P0032
{
  public class Solution
  {
    public int LongestValidParentheses(string s)
    {
      var stack = new Stack<(char ch, int index)>();
      var ans = 0;

      for (var i = 0; i < s.Length; i++)
      {
        var ch = s[i];

        if (ch == '(')
        {
          stack.Push((ch, i));
        }
        else
        {
          if (stack.Count > 0 && stack.Peek().ch == '(')
          {
            stack.Pop();

            var length = stack.Count == 0
              ? i + 1
              : i - stack.Peek().index;

            ans = Math.Max(ans, length);
          }
          else
          {
            stack.Push((ch, i));
          }
        }
      }

      return ans;
    }
  }
}
