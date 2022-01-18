package com.vzh.leetcode;

import java.util.PriorityQueue;
import java.util.TreeSet;

/**
 * Problem: https://leetcode.com/problems/finding-3-digit-even-numbers/
 * Submission: https://leetcode.com/submissions/detail/597832247/
 */
public class P2094 {
  class Solution {
    public int[] findEvenNumbers(int[] digits) {
      var ans = new TreeSet<Integer>();

      for (int i = 0; i < digits.length; i++) {
        for (int j = 0; j < digits.length; j++) {
          for (int k = 0; k < digits.length; k++) {
            if (digits[i] == 0)
              continue;

            if (i == j || i == k || j == k)
              continue;

            if (digits[k] % 2 == 1)
              continue;

            ans.add(digits[i] * 100 + digits[j] * 10 + digits[k]);
          }
        }
      }

      return ans.stream().mapToInt(x -> x).toArray();
    }
  }
}
