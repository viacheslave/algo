package binarysearch;

import java.util.HashSet;
import java.util.LinkedList;

/*
 * Problem: https://binarysearch.com/problems/Make-Target-List-with-Increment-and-Double-Operations
 * Submission: https://binarysearch.com/problems/Make-Target-List-with-Increment-and-Double-Operations/submissions/7496488
 */
public class P0902 {
  class Solution {
    public int solve(int[] target) {
      var ans = 0;

      while (true) {
        var sum = 0;
        for (int i = 0; i < target.length; i++) {
          if (target[i] % 2 == 1) {
            ans++;
            target[i]--;
          }
          sum += target[i];
        }

        if (sum == 0)
          break;

        for (int i = 0; i < target.length; i++) {
          target[i] /= 2;
        }
        ans++;
      }

      return ans;
    }
  }
}