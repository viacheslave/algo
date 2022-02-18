package binarysearch;

import binarysearch.templates.Tree;

import java.util.LinkedList;

/*
 * Problem: https://binarysearch.com/problems/Next-Node-on-Its-Right
 * Submission: https://binarysearch.com/problems/Next-Node-on-Its-Right/submissions/7583555
 */
public class P0913 {
  class Solution {
    public Tree solve(Tree tree, int target) {
      var level = getTargetLevel(tree, target, 0);
      if (level == null)
        return null;

      LinkedList<Tree> ll = new LinkedList<>();
      fillLevel(tree, ll, 0, level);

      var listIterator = ll.listIterator();
      while (listIterator.hasNext()) {
        var el = listIterator.next();
        if (el.val == target) {
          return listIterator.hasNext() ? listIterator.next() : null;
        }
      }
      return null;
    }

    private Integer getTargetLevel(Tree node, int target, int level) {
      if (node == null)
        return null;

      if (node.val == target)
        return level;

      var left = getTargetLevel(node.left, target, level + 1);
      if (left != null)
        return left;

      return getTargetLevel(node.right, target, level + 1);
    }

    private void fillLevel(Tree node, LinkedList<Tree> ll, Integer level, Integer targetLevel) {
      if (node == null)
        return;

      if (level.equals(targetLevel))
        ll.offer(node);

      fillLevel(node.left, ll, level + 1, targetLevel);
      fillLevel(node.right, ll, level + 1, targetLevel);
    }


  }
}