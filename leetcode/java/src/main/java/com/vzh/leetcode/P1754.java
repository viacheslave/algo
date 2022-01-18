package com.vzh.leetcode;

import java.util.HashMap;
import java.util.TreeSet;

/**
 * Problem: https://leetcode.com/problems/largest-merge-of-two-strings/
 * Submission: https://leetcode.com/submissions/detail/588123104/
 */
public class P1754 {
  class Solution {
    public String largestMerge(String word1, String word2) {
      var w1 = 0;
      var w2 = 0;
      var result = new StringBuilder();

      // greedy
      while (w1 < word1.length() || w2 < word2.length()) {
        if (w1 == word1.length()) {
          result.append(word2.charAt(w2++));
          continue;
        }

        if (w2 == word2.length()) {
          result.append(word1.charAt(w1++));
          continue;
        }

        // if characters are equal
        // compare substrings of equal lengths (min)
        if (word1.charAt(w1) == word2.charAt(w2)) {
          var end = Math.min(word1.length() - w1, word2.length() - w2);
          var cmp = word1.substring(w1, w1 + end).compareTo(word2.substring(w2, w2 + end));

          if (cmp > 0)
            result.append(word1.charAt(w1++));
          else if (cmp < 0)
            result.append(word2.charAt(w2++));
          else {
            // choose larger word
            if (word1.substring(w1).compareTo(word2.substring(w2)) > 0)
              result.append(word1.charAt(w1++));
            else
              result.append(word2.charAt(w2++));
          }
        }
        else {
          if (word1.charAt(w1) > word2.charAt(w2))
            result.append(word1.charAt(w1++));
          else
            result.append(word2.charAt(w2++));
        }
      }
      return result.toString();
    }
  }
}
