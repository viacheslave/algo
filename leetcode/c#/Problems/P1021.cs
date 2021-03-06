namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/remove-outermost-parentheses/
///    Submission: https://leetcode.com/submissions/detail/233409142/
/// </summary>
internal class P1021
{
  public class Solution
  {
    public string RemoveOuterParentheses(string S)
    {
      var st = new Stack<char>();

      var indices = new List<int>();
      var outer = false;

      for (var i = 0; i < S.Length; i++)
      {
        var ch = S[i];

        if (ch == '(')
        {
          st.Push(ch);
          if (st.Count == 1 && !outer)
          {
            indices.Add(i);
            outer = true;
          }
        }
        else
        {
          st.Pop();
          if (st.Count == 0 && outer)
          {
            indices.Add(i);
            outer = false;
          }
        }
      }

      var sb = new StringBuilder(S);
      for (var i = indices.Count - 1; i >= 0; i--)
        sb.Remove(indices[i], 1);

      return sb.ToString();
    }
  }
}
