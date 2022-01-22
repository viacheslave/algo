package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;

/*
 * Problem: https://binarysearch.com/problems/Special-Product-List
 * Submission: https://binarysearch.com/problems/Special-Product-List/submissions/7352434
 */
public class P0006 {
  class Solution {
    public int[] solve(int[] nums) {
      var zeroes = new ArrayList<Integer>();
      for (int i = 0; i < nums.length; i++) {
        if (nums[i] == 0)
          zeroes.add(i);
      }

      int product = Arrays.stream(nums).boxed()
        .filter(x -> x != 0)
        .reduce(1, (a, b) -> a * b);

      var ans = new int[nums.length];
      for (int i = 0; i < nums.length; i++) {
        if (zeroes.size() == 0) {
          ans[i] = product / nums[i];
          continue;
        }

        if (zeroes.size() == 1 && nums[i] == 0) {
          ans[i] = product;
          continue;
        }

        ans[i] = 0;
      }

      return ans;
    }
  }
}