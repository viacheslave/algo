package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/The-Accountant
 * Submission: https://binarysearch.com/problems/The-Accountant/submissions/7295574
 */
public class P0062 {
  class Solution {
    public String solve(int n) {
      int power = 26;
      var sb = new StringBuffer();

      while (n > 0) {
        var digit = (n - 1) % power;

        var ch = (digit + 65);
        sb.insert(0, (char)ch);

        n = (n - digit) / power;
      }

      return sb.toString();
    }
  }
}