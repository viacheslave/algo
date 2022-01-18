package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Sort-by-Frequency-and-Value
 * Submission: https://binarysearch.com/problems/Sort-by-Frequency-and-Value/submissions/6647873
 */
public class P0088 {
  class Solution {
    public int[] solve(int[] nums) {
      var freqs = Arrays.stream(nums)
        .boxed()
        .collect(Collectors.groupingBy(x -> x, Collectors.counting()));

      var sortedFreqs = freqs.entrySet().stream()
        .sorted((a, b) -> {
          if (a.getValue() > b.getValue())
            return -1;
          if (a.getValue() < b.getValue())
            return 1;
          return b.getKey().compareTo(a.getKey());
        })
        .collect(Collectors.toList());

      var ans = new ArrayList<Integer>(nums.length);

      for (var entry : sortedFreqs) {
        for (var i = 0; i < entry.getValue(); i++)
          ans.add(entry.getKey());
      }

      return ans.stream().mapToInt(x -> x).toArray();
    }
  }
}