package binarysearch;

import java.util.Arrays;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.Objects;

/*
 * Problem: https://binarysearch.com/problems/Set-Split
 * Submission: https://binarysearch.com/problems/Set-Split/submissions/7430604
 */
public class P0547 {
  class Solution {
    public boolean solve(int[] nums) {
      var sum = Arrays.stream(nums).sum();
      if (sum % 2 == 1)
        return false;

      Arrays.sort(nums);

      var leftSum = 0;

      for (int i = 0; i < nums.length - 1; i++) {
        leftSum += nums[i];
        if (leftSum == sum - leftSum && nums[i] < nums[i + 1])
          return true;
      }

      return false;
    }
  }
}