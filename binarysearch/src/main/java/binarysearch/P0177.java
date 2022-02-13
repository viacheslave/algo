package binarysearch;

import binarysearch.templates.Tree;

import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Stack-Sequence
 * Submission: https://binarysearch.com/problems/Stack-Sequence/submissions/7531477
 */
public class P0177 {
  class Solution {
    public boolean solve(int[] pushes, int[] pops) {
      if (pushes.length != pops.length)
        return false;

      if (pushes.length == 0)
        return true;

      var pushIndex = 0;
      var popIndex = 0;
      var stack = new Stack<Integer>();

      while (true) {
        stack.push(pushes[pushIndex++]);

        while (!stack.empty() && popIndex < pops.length && stack.peek() == pops[popIndex]) {
          stack.pop();
          popIndex++;
        }

        if (pushIndex == pushes.length)
          return stack.isEmpty();
      }
    }
  }
}