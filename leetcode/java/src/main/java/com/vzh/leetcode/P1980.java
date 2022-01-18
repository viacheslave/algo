package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/find-unique-binary-string/
 * Submission: https://leetcode.com/submissions/detail/543490330/
 */
public class P1980 {
  class Solution {
    public String findDifferentBinaryString(String[] nums) {
      var set = new HashSet<Integer>();

      for (var s : nums)
        set.add(Integer.parseInt(s, 2));

      var ans = Integer.MIN_VALUE;

      for (var i = 0; ; ++i) {
        if (!set.contains(i)) {
          ans = i;
          break;
        }
      }

      var sb = new StringBuilder();
      for (var i = 0; i < nums.length; i++)
        sb.append('0');

      var pos = nums.length - 1;
      while (ans > 0) {
        if (ans % 2 == 1)
          sb.setCharAt(pos, '1');

        ans >>= 1;
        pos--;
      }

      return sb.toString();
    }
  }
}