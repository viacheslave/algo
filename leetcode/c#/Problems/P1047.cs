namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/
///    Submission: https://leetcode.com/submissions/detail/231272824/
/// </summary>
internal class P1047
{
  public class Solution
  {
    public string RemoveDuplicates(string S)
    {
      if (S.Length < 2)
        return S;

      var sb = new StringBuilder(S);

      while (true)
      {
        if (S.Length < 2)
          return sb.ToString();

        var pos = -1;
        for (var i = 1; i < sb.Length; i++)
        {
          if (sb[i] == sb[i - 1])
          {
            pos = i - 1;
            break;
          }
        }

        if (pos == -1)
          break;

        sb.Remove(pos, 2);

      }

      return sb.ToString();
    }
  }
}

/// <summary>
///    Problem: https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/
///    Submission: https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/submissions/840950244/
/// </summary>
internal class P1047_2
{
  public class Solution
  {
    public string RemoveDuplicates(string S)
    {
      var stack = new Stack<char>();

      foreach (var ch in S)
      {
        if (stack.Count == 0 || stack.Peek() != ch)
        {
          stack.Push(ch);
          continue;
        }

        stack.Pop();
      }

      return string.Join("", stack.Reverse().ToArray());
    }
  }
}
