package binarysearch;

import java.util.LinkedList;
import java.util.Queue;

/*
 * Problem: https://binarysearch.com/problems/Binary-Tree-to-Linked-List
 * Submission: https://binarysearch.com/problems/Binary-Tree-to-Linked-List/submissions/6916754
 */
public class P0231 {
  class Solution {
    public LLNode solve(Tree root) {
      if (root == null)
        return null;

      var head = new LLNode();
      var queue = new LinkedList<Tree>();

      traverse(root, queue);

      var current = head;
      while (!queue.isEmpty()) {
        var el = queue.poll();

        var l = new LLNode();
        l.val = el.val;

        current.next = l;
        current = current.next;
      }

      return head.next;
    }

    private void traverse(Tree node, Queue<Tree> ll) {
      if (node == null)
        return;

      traverse(node.left, ll);
      ll.add(node);
      traverse(node.right, ll);
    }

    public class LLNode {
      int val;
      LLNode next;
    }

    public class Tree {
      int val;
      Tree left;
      Tree right;
    }
  }
}