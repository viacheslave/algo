package binarysearch;

import java.util.ArrayList;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Space-Battle
 * Submission: https://binarysearch.com/problems/Space-Battle/submissions/7357918
 */
public class P0117 {
  class Solution {
    public int[] solve(int[] nums) {
      var stack = new Stack<Integer>();

      for (var num : nums) {
        if (stack.empty()) {
          stack.push(num);
          continue;
        }

        // positive is always pushed
        if (num > 0) {
          stack.push(num);
          continue;
        }

        if (num < 0) {
          var flag = true;

          while (!stack.empty()) {
            var peek = stack.peek();
            if (peek < 0) {
              break;
            }

            var peekAbs = Math.abs(peek);
            var numAbs = Math.abs(num);

            if (peekAbs == numAbs) {
              // both destroyed
              stack.pop();
              flag = false;
              break;
            }

            if (peekAbs < numAbs) {
              stack.pop();
            }
            else {
              flag = false;
              break;
            }
          }

          if (flag) {
            stack.push(num);
          }
        }
      }

      var ans = new ArrayList<>(stack);
      return ans.stream().mapToInt(x -> x).toArray();
    }
  }
}