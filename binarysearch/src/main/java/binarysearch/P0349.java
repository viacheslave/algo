package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Ways-to-Sum-Consecutive-Numbers-to-N
 * Submission: https://binarysearch.com/problems/Ways-to-Sum-Consecutive-Numbers-to-N/submissions/6828846
 */
public class P0349 {
  class Solution {
    public int solve(int n) {
      var sqrt = Math.sqrt(n);

      var ans = 1;
      for (var i = 2; i <= sqrt; i++) {
        if (n % i == 0) {
          if (i % 2 == 1)
            ans++;
          if (i != (n / i) && (n / i) % 2 == 1)
            ans++;
        }
      }

      if (n > 1 && n % 2 == 1)
        ans++;

      return ans;
    }
  }
}