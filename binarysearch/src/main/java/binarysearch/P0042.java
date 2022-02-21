package binarysearch;

import binarysearch.templates.LLNode;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Palindrome-Linked-List
 * Submission: https://binarysearch.com/problems/Palindrome-Linked-List/submissions/7606027
 */
public class P0042 {
  class Solution {
    public boolean solve(LLNode node) {
      var nodes = new Stack<LLNode>();
      var current = node;
      while (current != null) {
        nodes.push(current);
        current = current.next;
      }

      var half = nodes.size() / 2;

      var right = new Stack<LLNode>();
      while (right.size() < half) {
        right.push(nodes.pop());
      }

      if (nodes.size() > right.size())
        nodes.pop();

      while (!nodes.empty()) {
        var n1 = nodes.pop();
        var n2 = right.pop();
        if (n1.val != n2.val)
          return false;
      }

      return true;
    }
  }
}