package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.TreeSet;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Longest-Consecutive-Sequence
 * Submission: https://binarysearch.com/problems/Longest-Consecutive-Sequence/submissions/7332337
 */
public class P0130 {
  class Solution {
    public int solve(int[] nums) {
      if (nums.length == 0)
        return 0;

      nums = new TreeSet<Integer>(Arrays.stream(nums).boxed().collect(Collectors.toList()))
        .stream().mapToInt(x -> x).toArray();

      var ans = 1;
      var length = 1;

      for (var i = 1; i < nums.length; i++) {
        if (nums[i] == nums[i - 1] + 1) {
          length++;
        }
        else {
          length = 1;
        }

        ans = Math.max(ans, length);
      }

      return ans;
    }
  }
}