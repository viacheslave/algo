package binarysearch;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Linked-List-Folding
 * Submission: https://binarysearch.com/problems/Linked-List-Folding/submissions/6952451
 */
public class P0340 {
  class Solution {
    public LLNode solve(LLNode node) {
      if (node == null)
        return null;

      var count = 1;
      var current = node;

      while (current.next != null) {
        count++;
        current = current.next;
      }

      if (count % 2 == 1) {
        var num = count / 2;
        var stack = new Stack<LLNode>();

        current = node;
        while (stack.size() < num) {
          stack.add(current);
          current = current.next;
        }

        var midNode = current;
        var rightNode = current;

        while (!stack.empty()) {
          var newNode = new LLNode();
          newNode.val = stack.pop().val + rightNode.next.val;
          rightNode = rightNode.next;

          current.next = newNode;
          current = current.next;
        }

        return midNode;
      }
      else {
        var num = count / 2 - 1;
        var stack = new Stack<LLNode>();

        current = node;
        while (stack.size() < num) {
          stack.add(current);
          current = current.next;
        }

        var midNode = current;
        midNode.val += current.next.val;

        var rightNode = current.next;
        midNode.next = null;

        while (!stack.empty()) {
          var newNode = new LLNode();
          newNode.val = stack.pop().val + rightNode.next.val;
          rightNode = rightNode.next;

          current.next = newNode;
          current = current.next;
        }

        return midNode;
      }
    }

    class LLNode {
      int val;
      LLNode next;
    }
  }
}