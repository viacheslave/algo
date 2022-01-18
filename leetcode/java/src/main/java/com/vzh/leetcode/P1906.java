package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.TreeSet;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/minimum-absolute-difference-queries/
 * Submission: https://leetcode.com/submissions/detail/588651812/
 */
public class P1906 {
  class Solution {
    public int[] minDifference(int[] nums, int[][] queries) {
      var map = new ArrayList<ArrayList<Integer>>(100);

      // as all nums are 1..100
      // create a collection of sets for each 1..100
      // each set holds indices where num is located in nums
      for (var i = 0; i <= 100; i++) {
        map.add(new ArrayList<>());
      }

      for (var i = 0; i < nums.length; i++) {
        map.get(nums[i]).add(i);
      }

      var tree = map.stream()
        .map(TreeSet::new)
        .collect(Collectors.toList());

      var ans = new int[queries.length];

      for (int i = 0; i < queries.length; i++) {
        var v = 100;
        var query = queries[i];

        var list = new ArrayList<Integer>();

        // for each set
        // find if there's an index inside the query []
        // get ceiling and floor
        for (var t = 0; t < tree.size(); t++) {
          var num = t;

          var f1 = tree.get(t).ceiling(query[0]);
          var f2 = tree.get(t).floor(query[1]);

          if ((f1 != null && query[0] <= f1 && f1 <= query[1]) || (f2 != null && query[0] <= f2 && f2 <= query[1]))
            list.add(num);
        }

        if (list.size() == 1) {
          ans[i] = -1;
        }
        else {
          // get min interval
          var min = Integer.MAX_VALUE;
          for (var j = 1; j < list.size(); j++) {
            min = Math.min(min, list.get(j) - list.get(j - 1));
          }

          ans[i] = min;
        }
      }

      return ans;
    }
  }
}