package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Roman-Numeral-to-Integer
 * Submission: https://binarysearch.com/problems/Roman-Numeral-to-Integer/submissions/6881130
 */
public class P0221 {
  class Solution {
    public int solve(String numeral) {
      int m = 0,
        d = 0,
        c = 0, l = 0, x = 0, v = 0, i = 0;

      for (var a = 0; a < numeral.length(); a++)
      {
        var ch = numeral.charAt(a);

        if (ch == 'M')
          m += 1000;
        if (ch == 'D')
          d += 500;

        if (ch == 'C') {
          if ((a + 1) < numeral.length() && (numeral.charAt(a + 1) == 'D' || numeral.charAt(a + 1) == 'M')) {
            c -= 100;
          }
          else {
            c += 100;
          }
        }

        if (ch == 'L')
          l += 50;

        if (ch == 'X') {
          if ((a + 1) < numeral.length() && (numeral.charAt(a + 1) == 'L' || numeral.charAt(a + 1) == 'C')) {
            x -= 10;
          }
          else {
            x += 10;
          }
        }

        if (ch == 'V')
          v += 5;

        if (ch == 'I') {
          if ((a + 1) < numeral.length() && (numeral.charAt(a + 1) == 'V' || numeral.charAt(a + 1) == 'X')) {
            i -= 1;
          }
          else {
            i += 1;
          }
        }
      }

      return (m + d + c + l + x + v + i);
    }
  }
}