package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Ambigram-Detection
 * Submission: https://binarysearch.com/problems/Ambigram-Detection/submissions/6666339
 */
public class P0799 {
  class Solution {
    public int[] solve(int[] nums) {
      if (nums.length == 0)
        return new int[0];

      var end = 0;
      var count = 0;
      var current = nums[0];

      var ans = new ArrayList<Integer>();

      while (true) {
        if (end == nums.length)
          break;

        if (nums[end] != current) {
          current = nums[end];
          count = 0;
          continue;
        }

        count++;
        if (count <= 2) {
          ans.add(current);
        }

        end++;
      }

      return ans.stream()
        .mapToInt(x -> x)
        .toArray();
    }
  }
}