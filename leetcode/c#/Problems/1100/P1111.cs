namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/maximum-nesting-depth-of-two-valid-parentheses-strings/
///    Submission: https://leetcode.com/submissions/detail/587732066/
/// </summary>
internal class P1111
{
  public class Solution
  {
    public int[] MaxDepthAfterSplit(string seq)
    {
      var stack = new Stack<(int index, int depth)>();
      var pairs = new List<(int start, int end, int depth)>();

      for (int i = 0; i < seq.Length; i++)
      {
        var ch = seq[i];

        if (ch == '(')
        {
          if (stack.Count > 0)
            stack.Push((i, stack.Peek().depth + 1));
          else
            stack.Push((i, 0));
        }
        else
        {
          var item = stack.Pop();
          pairs.Add((item.index, i, item.depth));
        }
      }

      var depthDivider = pairs.Max(x => x.depth) / 2;

      var ans = new int[seq.Length];
      foreach (var pair in pairs)
      {
        if (pair.depth <= depthDivider)
        {
          ans[pair.start] = 0;
          ans[pair.end] = 0;
        }
        else
        {
          ans[pair.start] = 1;
          ans[pair.end] = 1;
        }
      }

      return ans;
    }
  }
}
