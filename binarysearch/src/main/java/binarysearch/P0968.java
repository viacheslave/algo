package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Characters-in-Each-Bracket-Depth
 * Submission: https://binarysearch.com/problems/Characters-in-Each-Bracket-Depth/submissions/7019605
 */
public class P0968 {
  class Solution {
    public int[] solve(String s) {
      var level = 0;

      var ans = new ArrayList<Integer>();

      for (int i = 0; i < s.length(); i++) {
        if (s.charAt(i) == '(') {
          level++;

          if (ans.size() == level - 1) {
            ans.add(0);
          }
        }
        else if (s.charAt(i) == ')') {
          level--;
        }
        else {
          ans.set(level - 1, ans.get(level - 1) + 1);
        }
      }

      return ans.stream().mapToInt(x -> x).toArray();
    }
  }
}