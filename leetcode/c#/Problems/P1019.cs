namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/next-greater-node-in-linked-list/
///    Submission: https://leetcode.com/submissions/detail/295557780/
/// </summary>
internal class P1019
{
  public class Solution
  {
    public int[] NextLargerNodes(ListNode head)
    {
      if (head == null)
        return Array.Empty<int>();

      var dict = new SortedDictionary<int, int>();
      var stack = new Stack<(int index, int value)>();
      var index = 0;

      var current = head;
      while (current != null)
      {
        Unwind(stack, index, current.val, dict);

        stack.Push((index, current.val));
        current = current.next;
        index++;
      }

      for (int i = 0; i < index; i++)
      {
        if (!dict.ContainsKey(i))
          dict[i] = 0;
      }


      return dict.Values.ToArray();
    }

    private void Unwind(Stack<(int index, int value)> stack, int index, int current, SortedDictionary<int, int> dict)
    {
      while (stack.Count > 0 && stack.Peek().value < current)
      {
        var item = stack.Pop();
        dict.Add(item.index, current);
      }
    }
  }
}
