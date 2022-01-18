package com.vzh.leetcode;

import com.vzh.leetcode.helpers.Employee;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;

/*
 * Problem: https://leetcode.com/problems/check-if-all-as-appears-before-all-bs/
 * Submission: https://leetcode.com/submissions/detail/611355024/
 */
class P2124 {
  class Solution {
    public boolean checkString(String s) {
      if (s.length() == 1)
        return true;

      return s.lastIndexOf('a') < (s.indexOf('b') == -1 ? Integer.MAX_VALUE : s.indexOf('b'));
    }
  }
}