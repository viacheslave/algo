package binarysearch;

import binarysearch.templates.Tree;

import java.util.ArrayList;
import java.util.LinkedList;

/*
 * Problem: https://binarysearch.com/problems/Tree-Shifting
 * Submission: https://binarysearch.com/problems/Tree-Shifting/submissions/7264361
 */
public class P0834 {
  class Solution {
    public Tree solve(Tree root) {
      if (root == null)
        return root;

      var queues = new ArrayList<LinkedList<Tree>>();
      levels(root, queues, 0);

      var ans = new Tree();
      ans.val = root.val;

      traverse(ans, queues, 1);
      return ans;
    }

    private void levels(Tree node, ArrayList<LinkedList<Tree>> queues, int level) {
      if (node == null)
        return;

      if (queues.size() == level) {
        queues.add(new LinkedList<>());
      }

      queues.get(level).add(node);
      levels(node.right, queues, level + 1);
      levels(node.left, queues, level + 1);
    }

    private void traverse(Tree current, ArrayList<LinkedList<Tree>> queues, int level) {
      if (level >= queues.size())
        return;

      if (!queues.get(level).isEmpty()) {
        current.right = new Tree();
        current.right.val = queues.get(level).poll().val;

        traverse(current.right, queues, level + 1);
      }

      if (!queues.get(level).isEmpty()) {
        current.left = new Tree();
        current.left.val = queues.get(level).poll().val;

        traverse(current.left, queues, level + 1);
      }
    }


  }
}