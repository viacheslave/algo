package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Trimmed-Palindromes
 * Submission: https://binarysearch.com/problems/Trimmed-Palindromes/submissions/6975485
 */
public class P0321 {
  class Solution {
    public int solve(String s) {
      var ans = 0;
      var n = s.length();

      for (var i = 0; i < n; i++) {
        ans++;
        var l = i - 1;
        var r = i + 1;

        while (l >= 0 && r < n) {
          if (s.charAt(l) == s.charAt(r)) {
            ans++;
            l--;
            r++;
            continue;
          }
          break;
        }
      }

      for (var i = 1; i < n; i++) {
        var l = i - 1;
        var r = i;

        while (l >= 0 && r < n) {
          if (s.charAt(l) == s.charAt(r)) {
            ans++;
            l--;
            r++;
            continue;
          }
          break;
        }
      }

      return ans;
    }
  }
}