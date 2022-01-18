package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Odd-Palindrome
 * Submission: https://binarysearch.com/problems/Odd-Palindrome/submissions/6975643
 */
public class P0362 {
  class Solution {
    public boolean solve(String s) {
      for (var i = 1; i < s.length(); i++) {
        if (s.charAt(i) == s.charAt(i - 1))
          return false;
      }

      return true;
    }
  }
}