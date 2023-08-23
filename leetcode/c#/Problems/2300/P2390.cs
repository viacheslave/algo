namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/removing-stars-from-a-string/
///    Submission: https://leetcode.com/submissions/detail/788123105/
/// </summary>
internal class P2390
{
  public class Solution
  {
    public string RemoveStars(string s)
    {
      var stack = new Stack<char>();

      for (int i = 0; i < s.Length; i++)
      {
        if (s[i] == '*')
        {
          if (stack.Count > 0)
          {
            stack.Pop();
          }
        }
        else
        {
          stack.Push(s[i]);
        }
      }

      return new string(stack.Reverse().ToArray());
    }
  }
}
