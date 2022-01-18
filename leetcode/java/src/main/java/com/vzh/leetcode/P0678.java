package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/valid-parenthesis-string/
 * Submission: https://leetcode.com/submissions/detail/602800625/
 */
public class P0678 {
  class Solution {
    public boolean checkValidString(String s) {
      var strs = new HashSet<String>();
      strs.add("");

      for (var i = 0; i < s.length(); i++) {

        var ch = s.charAt(i);
        var following = new HashSet<String>();

        for (var str : strs) {
          var strEndsWithOpenBracket = str.length() > 0 && str.charAt(str.length() - 1) == '(';

          if (ch == '(') {
            following.add(str + ch);
          }
          else if (ch == ')') {
            if (strEndsWithOpenBracket) {
              following.add(str.substring(0, str.length() - 1));
            }
            else {
              following.add(str + ch);
            }
          }
          else {
            following.add(str);
            following.add(str + '(');

            // '('
            if (strEndsWithOpenBracket) {
              following.add(str.substring(0, str.length() - 1));
            }
            // ')'
            else {
              following.add(str + ')');
            }
          }
        }

        strs = following;
      }

      return strs.stream().anyMatch(x -> x.length() == 0);
    }
  }
}