package binarysearch;

import java.util.TreeMap;

/*
 * Problem: https://binarysearch.com/problems/Add-Binary-Numbers
 * Submission: https://binarysearch.com/problems/Add-Binary-Numbers/submissions/6646600
 */
public class P0352 {
  class Solution {
    public int solve(int[] nums, int target) {
      var prefixSums = new int[nums.length + 1];

      for (int i = 1; i <= nums.length; i++) {
        prefixSums[i] = prefixSums[i - 1] + nums[i - 1];
      }

      var map = new TreeMap<Integer, Integer>();
      for (var pre : prefixSums) {
        map.putIfAbsent(pre, 0);
        map.put(pre, map.get(pre) + 1);
      }

      var ans = 0;

      for (var entry : map.entrySet()) {
        var key = entry.getKey();
        var value = entry.getValue();
        var search = key - target;

        if (map.containsKey(search)) {
          if (key == search) {
            ans += value * (value - 1) / 2;
          }
          else {
            ans += value * map.get(search);
          }
        }
      }

      return ans;
    }
  }
}