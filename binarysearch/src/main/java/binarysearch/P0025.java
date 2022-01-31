package binarysearch;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Unique-Occurrences
 * Submission: https://binarysearch.com/problems/Unique-Occurrences/submissions/7430545
 */
public class P0025 {
  class Solution {
    public boolean solve(int[] nums) {
      var map = Arrays.stream(nums).boxed()
        .collect(Collectors.groupingBy(x -> x, Collectors.counting()));

      return map.values().stream().distinct().count() == map.size();
    }
  }
}