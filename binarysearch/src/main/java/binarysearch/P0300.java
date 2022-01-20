package binarysearch;

import binarysearch.templates.LLNode;
import binarysearch.templates.Tree;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

/*
 * Problem: https://binarysearch.com/problems/Level-Order-Binary-Tree-to-Linked-List
 * Submission: https://binarysearch.com/problems/Level-Order-Binary-Tree-to-Linked-List/submissions/7335156
 */
public class P0300 {
  class Solution {
    public LLNode solve(Tree root) {
      var levels = new ArrayList<List<Integer>>();

      // recursive
      rec(root, levels, 0);

      var ans = new LLNode();
      var current = ans;

      for (List<Integer> level : levels) {
        for (Integer integer : level) {
          current.next = new LLNode();
          current.next.val = integer;

          current = current.next;
        }
      }

      return ans.next;
    }

    private void rec(Tree node, ArrayList<List<Integer>> levels, int level) {
      if (node == null) {
        return;
      }

      if (level >= levels.size()) {
        levels.add(new ArrayList<>());
      }

      var arr = levels.get(level);
      arr.add(node.val);

      rec(node.left, levels,level + 1);
      rec(node.right, levels,level + 1);
    }
  }
}