namespace LeetCode.Naive.Problems;

/// <summary>
///    Problem: https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/
///    Submission: https://leetcode.com/submissions/detail/344558223/
/// </summary>
internal class P1457
{
  public class Solution
  {
    public int PseudoPalindromicPaths(TreeNode root)
    {
      var list = new List<int>();
      return Traverse(root, list);
    }

    private int Traverse(TreeNode node, List<int> list)
    {
      if (node == null)
        return 0;

      list.Add(node.val);

      var val = 0;

      if (node.left == null && node.right == null)
        val = IsPalindrome(list) ? 1 : 0;
      else
        val = Traverse(node.left, list) + Traverse(node.right, list);

      list.RemoveAt(list.Count - 1);

      return val;
    }

    private bool IsPalindrome(List<int> list)
    {
      var odds = list.GroupBy(d => d).ToDictionary(x => x.Key, x => x.Count())
        .Where(x => x.Value % 2 == 1)
        .Count();

      return odds <= 1;
    }
  }
}

/// <summary>
///    Problem: https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/
///    Submission: https://leetcode.com/submissions/detail/799425473/
///    Optimized
/// </summary>
internal class P1457_2
{
  public class Solution
  {
    public int PseudoPalindromicPaths(TreeNode root)
    {
      var list = new int[10];
      return Traverse(root, list);
    }

    private int Traverse(TreeNode node, int[] list)
    {
      if (node == null)
        return 0;

      list[node.val]++;

      int val;
      if (node.left == null && node.right == null)
      {
        val = IsPalindrome(list) ? 1 : 0;
      }
      else
      {
        val = Traverse(node.left, list) + Traverse(node.right, list);
      }

      list[node.val]--;
      return val;
    }

    private bool IsPalindrome(int[] list)
    {
      var odds = 0;
      for (int i = 0; i < list.Length; i++)
      {
        if (list[i] % 2 == 1)
          odds++;
      }

      return odds <= 1;
    }
  }

}
