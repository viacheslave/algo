using System.Numerics;

namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/using-a-robot-to-print-the-lexicographically-smallest-string/
///    Submission: https://leetcode.com/problems/using-a-robot-to-print-the-lexicographically-smallest-string/submissions/818593711/
/// </summary>
internal class P2434
{
  public class Solution
  {
    public string RobotWithString(string s)
    {
      var lastOcc = new int[26];
      Array.Fill(lastOcc, -1);

      for (int i = 0; i < s.Length; i++)
      {
        lastOcc[s[i] - 97] = i;
      }

      var ch = 'a';
      var stack = new Stack<char>();
      var ans = new StringBuilder();

      //"vzhofnpo"
      for (int i = 0; i < s.Length; i++)
      {
        while (lastOcc[ch - 97] < i)
          ch++;

        while (stack.Count() > 0 && stack.Peek() <= ch)
          ans.Append(stack.Pop());

        if (s[i] == ch)
        {
          ans.Append(s[i]);
          continue;
        }

        if (lastOcc[ch - 97] > i)
        {
          stack.Push(s[i]);
        }
      }

      // unwind the stack
      while (stack.Count() > 0)
      {
        ans.Append(stack.Pop());
      }

      return ans.ToString();
    }
  }
}
