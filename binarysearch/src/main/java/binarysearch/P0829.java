package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Reverse-Equivalent-Pairs
 * Submission:https://binarysearch.com/problems/Reverse-Equivalent-Pairs/submissions/7124056
 */
public class P0829 {
  class Solution {
    public int solve(int[] nums) {
      for (int i = 0; i < nums.length; i++) {
        var reverse = new StringBuilder(String.valueOf(nums[i])).reverse().toString();
        nums[i] -= Integer.parseInt(reverse);
      }

      var mod = (int)1e9 + 7;
      var ans = 0L;

      var mp = Arrays.stream(nums).boxed()
        .collect(Collectors.groupingBy(x -> x, Collectors.counting()));

      for (var e : mp.entrySet()) {
        ans += e.getValue() * (e.getValue() + 1) / 2;
      }

      return (int)(ans % mod);
    }
  }
}