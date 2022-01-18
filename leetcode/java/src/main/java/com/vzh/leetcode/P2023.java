package com.vzh.leetcode;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/number-of-pairs-of-strings-with-concatenation-equal-to-target/
 * Submission: https://leetcode.com/submissions/detail/569539507/
 */
public class P2023 {
  class Solution {
    public int numOfPairs(String[] nums, String target) {
      HashMap<Integer, HashSet<Integer>> starts = new HashMap<>();
      HashMap<Integer, HashSet<Integer>> ends = new HashMap<>();

      for (var i = 0; i < nums.length; i++) {
        var num = nums[i];
        if (target.startsWith(num)) {
          starts.putIfAbsent(num.length(), new HashSet<>());
          starts.get(num.length()).add(i);
        }

        if (target.endsWith(num)) {
          ends.putIfAbsent(target.length() - num.length(), new HashSet<>());
          ends.get(target.length() - num.length()).add(i);
        }
      }

      var ans = 0;

      for (var i = 0; i < target.length(); i++) {
        var s = starts.get(i);
        var e = ends.get(i);

        if (s != null && e != null) {
          var same = 0;
          for (var index : s) {
            if (e.contains(index))
              same++;
          }

          ans += s.size() * e.size() - same;
        }
      }

      return ans;
    }
  }
}