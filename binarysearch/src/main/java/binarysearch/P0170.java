package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Number-of-Unique-Binary-Search-Trees
 * Submission: https://binarysearch.com/problems/Number-of-Unique-Binary-Search-Trees/submissions/7380503
 */
public class P0170 {
  class Solution {
    public int solve(int n) {
      var memo = new int[n + 1];
      return count(n, memo);
    }

    private int count(int n, int[] memo) {
      if (n == 0)
        return 1;

      if (memo[n - 1] != 0)
        return memo[n - 1];

      var sum = 0;
      var mod = (int)1e9 + 7;

      for (var i = 0; i < n; i++) {
        if (i == 0 || i == n - 1) {
          sum += count(n - 1, memo);
        }
        else {
          long value = ((long)count(i, memo)) * count(n - i - 1, memo);
          sum += (value % mod);
        }
        sum %= mod;
      }

      memo[n - 1] = sum;
      return sum;
    }
  }
}