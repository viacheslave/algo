package com.vzh.leetcode;

import java.util.Arrays;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/count-vowel-substrings-of-a-string/
 * Submission: https://leetcode.com/submissions/detail/583540821/
 */
public class P2062 {
  class Solution {
    public int countVowelSubstrings(String word) {
      var ans = 0;

      for (int i = 0; i < word.length(); i++) {
        var set = new HashSet<Character>();

        for (int j = i; j < word.length(); j++) {
          var ch = word.charAt(j);
          if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            set.add(ch);
          else
            break;

          if (set.size() >= 5)
            ans++;
        }
      }

      return ans;
    }
  }
}