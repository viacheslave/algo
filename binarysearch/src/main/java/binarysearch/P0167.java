package binarysearch;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;

/*
 * Problem: https://binarysearch.com/problems/Subsequence-Sum
 * Submission: https://binarysearch.com/problems/Subsequence-Sum/submissions/7303683
 */
public class P0167 {
  class Solution {
    public int solve(int[] nums) {

      var n = nums.length;
      var arr = new int[n];

      for (int i = 0; i < n; i++) {
        arr[i] = nums[i] - i;
      }

      // same indices
      var map = new HashMap<Integer, List<Integer>>();
      for (int i = 0; i < n; i++) {
        map.putIfAbsent(arr[i], new ArrayList<>());
        map.get(arr[i]).add(nums[i]);
      }

      var ans =
        map.values().stream()
          .map(integers -> (Integer) integers.stream().mapToInt(x -> x).sum())
          .max(Comparator.naturalOrder());

      return ans.get();
    }
  }
}