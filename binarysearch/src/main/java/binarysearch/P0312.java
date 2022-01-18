package binarysearch;

import java.util.HashSet;

/*
 * Problem: https://binarysearch.com/problems/Ambigram-Detection
 * Submission: https://binarysearch.com/problems/Remove-Half-of-the-List/submissions/6665494
 */
public class P0312 {
  class Solution {
    public boolean solve(int[] nums, int k) {
      var visited = new HashSet<Integer>();

      return CanReach(nums, k, visited);
    }

    private boolean CanReach(int[] nums, int k, HashSet<Integer> visited) {
      if (k == nums.length - 1)
        return true;

      if (visited.contains(k))
        return false;

      visited.add(k);

      var left = k - nums[k];
      var right = k + nums[k];

      return (left >= 0 && CanReach(nums, left, visited))
        || ( right < nums.length && CanReach(nums, right, visited));
    }
  }
}