namespace LeetCode.Naive.Problems;

internal class P0084
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-rectangle-in-histogram/
  ///    Submission: https://leetcode.com/submissions/detail/414260391/
  /// </summary>
  public class Solution
  {
    public int LargestRectangleArea(int[] heights)
    {
      var ans = 0;

      if (heights.Length == 0)
        return 0;

      for (var i = 0; i < heights.Length; i++)
      {
        ans = Math.Max(ans, heights[i]);
        var min = heights[i];

        for (var j = i - 1; j >= 0; j--)
        {
          if (heights[j] == 0)
            break;

          min = Math.Min(min, heights[j]);
          ans = Math.Max(ans, ((i - j) + 1) * min);
        }
      }

      return ans;
    }
  }

  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-rectangle-in-histogram/
  ///    Submission: https://leetcode.com/submissions/detail/630226002/
  /// </summary>
  public class Solution2
  {
    public int LargestRectangleArea(int[] heights)
    {
      var n = heights.Length;
      if (n == 0)
        return 0;

      var ans = 0;
      var stack = new Stack<StackItem>();

      for (var i = 0; i < heights.Length; i++)
      {
        var h = heights[i];

        if (stack.Count == 0 || stack.Peek().value <= h)
        {
          stack.Push(new StackItem(i, h));
          continue;
        }

        // pop recursively
        StackItem peek = stack.Peek();
        StackItem el = null;

        while (stack.Count > 0 && stack.Peek().value > h)
        {
          el = stack.Pop();
          ans = Math.Max(ans, (peek.index - el.index + 1) * el.value);
        }

        // if there were at least one pop
        // add the last item back with min value (h)
        if (el != null)
        {
          stack.Push(new StackItem(el.index, h));
        }

        stack.Push(new StackItem(i, h));
      }

      // iterate over stack to find max monotonous value
      var arr = stack
        .Reverse().ToArray();

      for (int i = 0; i < arr.Length; i++)
      {
        ans = Math.Max(ans,
          (arr[arr.Length - 1].index - arr[i].index + 1) * arr[i].value);
      }

      return ans;
    }

    class StackItem
    {
      public int index;
      public int value;

      public StackItem(int index, int value)
      {
        this.index = index;
        this.value = value;
      }
    }
  }

}
