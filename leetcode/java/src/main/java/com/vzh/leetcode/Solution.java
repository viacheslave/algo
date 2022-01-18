package com.vzh.leetcode;

import java.util.*;

class Solution {
  public String[] divideString(String s, int k, char fill) {
    var ans = new ArrayList<String>();
    var start = 0;

    while (start < s.length()) {
      var end = start + k - 1;
      if (end < s.length()) {
        ans.add(s.substring(start, start + k));
      }
      else {
        var a = new StringBuilder(s.substring(start));
        while (a.length() != k) {
          a.append(fill);
          ans.add(a.toString());
        }
      }
    }

    return ans.toArray(String[]::new);
  }
}