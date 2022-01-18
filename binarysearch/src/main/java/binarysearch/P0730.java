package binarysearch;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.PriorityQueue;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Binary-Search-Tree-Iterator
 * Submission: https://binarysearch.com/problems/Binary-Search-Tree-Iterator/submissions/6910405
 */
public class P0730 {
  class BSTIterator {
    private final PriorityQueue<Tree> pq = new PriorityQueue<>(Comparator.comparingInt(x -> x.val));

    public BSTIterator(Tree root) {
      var stack = new Stack<Tree>();
      stack.add(root);

      while (!stack.empty()) {
        var el = stack.pop();
        pq.add(el);

        if (el.left != null)
          stack.add(el.left);
        if (el.right != null)
          stack.add(el.right);
      }
    }

    public int next() {
      return pq.poll().val;
    }

    public boolean hasnext() {
      return pq.peek() != null;
    }
  }

  public class Tree {
    int val;
    Tree left;
    Tree right;
  }
}