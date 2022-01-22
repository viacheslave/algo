package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Maximal-Sublist-Product
 * Submission: https://binarysearch.com/problems/Maximal-Sublist-Product/submissions/7352530
 */
public class P0136 {
  class Solution {
    public int solve(int[] nums) {
      var n = nums.length;
      var zeroes = new ArrayList<Integer>();

      for (int i = 0; i < n; i++) {
        if (nums[i] == 0)
          zeroes.add(i);
      }

      // all zeros
      if (zeroes.size() == n)
        return 0;

      // split by zeros
      var segments = new ArrayList<Integer[]>();

      zeroes.add(0, -1);
      zeroes.add(n);

      for (int i = 1; i < zeroes.size(); i++) {
        if (zeroes.get(i) > zeroes.get(i - 1) + 1) {
          segments.add(new Integer[]{ zeroes.get(i - 1) + 1, zeroes.get(i) - 1 });
        }
      }

      var ans = Integer.MIN_VALUE;

      // min ans is zero
      if (zeroes.size() > 2) {
        ans = 0;
      }

      for (var segment : segments) {
        var negatives = new ArrayList<Integer>();

        // split by negatives
        for (int i = segment[0]; i <= segment[1] ; i++) {
          if (nums[i] < 0)
            negatives.add(i);
        }

        int product = 0;

        if (negatives.size() % 2 == 0) {
          product = getProduct(nums, segment[0], segment[1]);
        }
        else {
          product = Math.max(
            Math.max(
              getProduct(nums, segment[0], negatives.get(0) - 1),
              getProduct(nums, negatives.get(0) + 1, segment[1])
            ),
            Math.max(
              getProduct(nums, segment[0], negatives.get(negatives.size() - 1) - 1),
              getProduct(nums, negatives.get(negatives.size() - 1) + 1, segment[1])
            )
          );

          product = Math.max(
            product,
            getProduct(nums, segment[0], segment[1])
          );
        }

        ans = Math.max(ans, product);
      }

      return ans;
    }

    private int getProduct(int[] nums, Integer from, Integer to) {
      if (from > to)
        return  Integer.MIN_VALUE;

      var ans = 1;

      for (int i = from; i <= to; i++) {
        ans = ans * nums[i];
      }

      return ans;
    }
  }
}