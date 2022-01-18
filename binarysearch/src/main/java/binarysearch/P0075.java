package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Making-Change
 * Submission: https://binarysearch.com/problems/Making-Change/submissions/6968051
 */
public class P0075 {
  class Solution {
    public int solve(int n) {
      var ans = 0;
      var coins = new int[] { 25, 10, 5, 1 };
      for (var  i = 0 ; i < coins.length; i++) {
        var coin = coins[i];

        if (n >= coin) {
          var gain = n / coin;
          n %= coin;
          ans += gain;
        }
      }

      return ans;
    }
  }
}