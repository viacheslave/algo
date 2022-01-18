package binarysearch;

import java.util.Arrays;
import java.util.Comparator;
import java.util.Map;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Remove-Half-of-the-List
 * Submission: https://binarysearch.com/problems/Remove-Half-of-the-List/submissions/6665494
 */
public class P0905 {
  class Solution {
    public int solve(int[] nums) {
      var arr = Arrays
        .stream(nums)
        .boxed()
        .collect(Collectors.groupingBy(x -> x, Collectors.counting()))
        .entrySet()
        .stream()
        .sorted(Map.Entry.comparingByValue(Comparator.reverseOrder()))
        .collect(Collectors.toList());

      var ans = 0;
      var count = 0;
      var atLeastHalf = nums.length % 2 == 0
        ? nums.length / 2
        : nums.length / 2 + 1;

      for (var entry : arr) {
        ans++;
        count += entry.getValue();
        if (count >= atLeastHalf)
          return ans;
      }

      return ans;
    }
  }
}