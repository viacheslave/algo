package binarysearch;

import java.util.HashSet;
import java.util.PriorityQueue;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Ugly-Number-Sequel
 * Submission: https://binarysearch.com/problems/Ugly-Number-Sequel/submissions/6952307
 */
public class P0493 {
  class Solution {
    public int solve(int n) {
      var pr = new PriorityQueue<Integer>();

      int ans = 1;
      int index = 0;

      pr.add(ans);

      var set = new HashSet<Integer>();

      while (true) {
        ans = pr.poll();

        if (set.contains(ans))
          continue;

        pr.add(2 * ans);
        pr.add(3 * ans);
        pr.add(5 * ans);

        set.add(ans);

        index++;
        if (index == n + 1)
          return ans;
      }
    }
  }
}