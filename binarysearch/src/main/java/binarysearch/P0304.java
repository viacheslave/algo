package binarysearch;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Linked-List-to-ZigZag-Tree-Path
 * Submission: https://binarysearch.com/problems/Linked-List-to-ZigZag-Tree-Path/submissions/8153084
 */
public class P0304 {
  class Solution {
    public Tree solve(LLNode node) {
      if (node == null)
        return null;

      var root = new Tree();
      root.val = node.val;

      var currentTree = root;
      var currentNode = node;
      while (currentNode.next != null) {
        var next = new Tree();
        next.val = currentNode.next.val;

        if (next.val < currentTree.val) {
          currentTree.left = next;
        }
        else {
          currentTree.right = next;
        }

        currentTree = next;
        currentNode = currentNode.next;
      }

      return root;
    }
  }

  class Tree {
    int val;
    Tree left;
    Tree right;
  }

  class LLNode {
    int val;
    LLNode next;
  }
}