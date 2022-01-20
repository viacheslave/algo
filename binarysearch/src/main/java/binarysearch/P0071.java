package binarysearch;

import binarysearch.templates.Tree;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Kth-Smallest-in-a-Binary-Search-Tree
 * Submission: https://binarysearch.com/problems/Kth-Smallest-in-a-Binary-Search-Tree/submissions/7331223
 */
public class P0071 {
  class Solution {
    public int solve(Tree root, int k) {
      var num = 0;
      var stack = new Stack<Tree>();
      var current = root;

      stack.push(current);
      current = current.left;

      while (true) {
        // push all left nodes
        while (current != null) {
          stack.push(current);
          current = current.left;
        }

        if (stack.empty()) {
          break;
        }

        var el = stack.pop();
        num++;

        if (num == k + 1)
          return el.val;

        current = el.right;
      }

      return -1;
    }
  }
}