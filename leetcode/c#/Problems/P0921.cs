namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/
///    Submission: https://leetcode.com/submissions/detail/239778418/
/// </summary>
internal class P0921
{
  public class Solution
  {
    public int MinAddToMakeValid(string S)
    {
      var st = new Stack<char>();
      var count = 0;

      for (int i = 0; i < S.Length; i++)
      {
        if (S[i] == '(')
        {
          st.Push('(');
        }

        if (S[i] == ')')
        {
          if (st.Count == 0 || st.Peek() == ')')
          {
            count++;
            continue;
          }

          st.Pop();
        }
      }

      return count + st.Count;
    }
  }
}
