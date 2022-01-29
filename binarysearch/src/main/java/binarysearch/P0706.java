package binarysearch;

import java.util.Arrays;
import java.util.Comparator;
import java.util.HashSet;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Smallest-Intersecting-Element
 * Submission: https://binarysearch.com/problems/Smallest-Intersecting-Element/submissions/7389822
 */
public class P0706 {
  class Solution {
    public int solve(int[][] matrix) {
      if (matrix.length == 0 || matrix[0].length == 0)
        return -1;

      if (matrix.length == 1)
        return Arrays.stream(matrix[0]).min().getAsInt();

      var sets = Arrays.stream(matrix)
        .map(arr -> new HashSet<>(
          Arrays.stream(arr).boxed().collect(Collectors.toList())))
        .collect(Collectors.toList());

      var intersection = sets.get(0);

      for (var i = 1; i < sets.size(); i++) {
        intersection.retainAll(sets.get(i));
      }

      if (intersection.size() == 0)
        return -1;

      return intersection.stream().min(Comparator.naturalOrder()).get();
    }
  }
}