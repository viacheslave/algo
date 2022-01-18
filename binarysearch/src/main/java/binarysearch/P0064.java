package binarysearch;

import java.util.LinkedList;
import java.util.Queue;

/*
 * Problem: https://binarysearch.com/problems/Leftmost-Deepest-Tree-Node
 * Submission: https://binarysearch.com/problems/Leftmost-Deepest-Tree-Node/submissions/6951748
 */
public class P0064 {
  class Solution {
    public int solve(Tree root) {
      Queue<QueueItem> queue = new LinkedList<>();
      queue.add(new QueueItem(root, 0));

      Tree maxNode = root;
      int maxLevel = 0;

      while (!queue.isEmpty()) {
        var el = queue.poll();
        if (el.level > maxLevel) {
          maxLevel = el.level;
          maxNode = el.node;
        }

        if (el.node.left != null) {
          queue.add(new QueueItem(el.node.left, el.level + 1));
        }

        if (el.node.right != null) {
          queue.add(new QueueItem(el.node.right, el.level + 1));
        }
      }

      return maxNode.val;
    }

    class QueueItem {
      public Tree node;
      public int level;

      public QueueItem(Tree node, int level) {
        this.node = node;
        this.level = level;
      }
    }

    public class Tree {
      int val;
      Tree left;
      Tree right;
    }
  }
}