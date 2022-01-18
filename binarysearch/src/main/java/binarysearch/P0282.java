package binarysearch;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Tree-Traversal
 * Submission: https://binarysearch.com/problems/Tree-Traversal/submissions/6657483
 */
public class P0282 {
  /**
   * public class Tree {
   *   int val;
   *   Tree left;
   *   Tree right;
   * }
   */
  class Solution {
    public int solve(Tree root, String[] moves) {
      return Recursive(root, new Stack<Tree>(), moves, 0);
    }

    private int Recursive(Tree node, Stack<Tree> parents, String[] moves, int i) {
      if (i == moves.length)
        return node.val;

      Tree next;
      if (moves[i].equals("LEFT")) {
        next = node.left;
        parents.push(node);
      }
      else if (moves[i].equals("RIGHT")) {
        next = node.right;
        parents.push(node);
      }
      else {
        next = parents.pop();
      }

      return Recursive(next, parents, moves, i + 1);
    }

    public class Tree {
      int val;
      Tree left;
      Tree right;
    }

  }
}