using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Katas
{
  /// <summary>
  ///   https://www.codewars.com/kata/52bef5e3588c56132c0003bc
  ///   https://www.codewars.com/kata/reviews/5c1652cb7bb2545219000682/groups/5e04cab78c89df00014598f2
  /// </summary>
  public class SortBinaryTreeByLevels
  {
    class Kata
    {
      public static List<int> TreeByLevels(Node node)
      {
        var ans = new SortedDictionary<int, List<int>>();

        Traverse(node, 0, ans);

        return ans.Values.SelectMany(x => x).ToList();
      }

      private static void Traverse(Node node, int level, SortedDictionary<int, List<int>> ans)
      {
        if (node == null)
          return;

        if (!ans.ContainsKey(level)) ans[level] = new List<int>();
        ans[level].Add(node.Value);

        Traverse(node.Left, level + 1, ans);
        Traverse(node.Right, level + 1, ans);
      }
    }

    public class Node
    {
      public Node Left;
      public Node Right;
      public int Value;

      public Node(Node l, Node r, int v)
      {
        Left = l;
        Right = r;
        Value = v;
      }
    }
  }
}
