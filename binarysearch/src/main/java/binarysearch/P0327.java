package binarysearch;

import binarysearch.templates.Tree;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Leaves-in-Same-Level
 * Submission: https://binarysearch.com/problems/Leaves-in-Same-Level/submissions/7132913
 */
public class P0327 {
  class Solution {
    public boolean solve(Tree root) {
      Stack<Node> nodes = new Stack<>();
      HashSet<Integer> levels = new HashSet<>();

      // Iterative tree traversal
      nodes.add(new Node(root, 0));
      while (!nodes.empty()) {
        var node = nodes.pop();

        if (node.node.left == null && node.node.right == null) {
          levels.add(node.level);
        }

        if (node.node.left != null)
          nodes.add(new Node(node.node.left, node.level + 1));

        if (node.node.right != null)
          nodes.add(new Node(node.node.right, node.level + 1));
      }

      return levels.size() == 1;
    }

    static class Node {
      public Tree node;
      public int level;

      public Node(Tree node, int level) {
        this.node = node;
        this.level = level;
      }
    }
  }
}