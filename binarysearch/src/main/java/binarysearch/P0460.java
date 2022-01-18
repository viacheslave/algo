package binarysearch;

import java.util.HashMap;
import java.util.LinkedList;
import java.util.Objects;
import java.util.Queue;

/*
 * Problem: https://binarysearch.com/problems/Arithmetic-Subsequences
 * Submission: https://binarysearch.com/problems/Arithmetic-Subsequences/submissions/7166532
 */
public class P0460 {
  class Solution {
    public int solve(int[] nums) {
      var dp = new HashMap<Pair, Integer>();

      for (int i = 1; i < nums.length; i++) {
        for (int j = 0; j < i; j++) {
          var difference = nums[i] - nums[j];
          var pair = new Pair(i, difference);
          var pairPrev = new Pair(j, difference);

          var value = dp.getOrDefault(pairPrev, 0) + 1;
          dp.put(pair, dp.getOrDefault(pair, 0) + value);
        }
      }

      var sum = 0;
      for (var e : dp.entrySet()) {
        sum += e.getValue();
      }

      // calculate number of length of 2
      var two = nums.length * (nums.length - 1) / 2;

      return sum - two;
    }

    static class Pair {
      public int index;
      public int difference;

      public Pair(int index, int difference) {
        this.index = index;
        this.difference = difference;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Pair pair = (Pair) o;
        return index == pair.index && difference == pair.difference;
      }

      @Override
      public int hashCode() {
        return Objects.hash(index, difference);
      }

      @Override
      public String toString() {
        return "Pair{" +
          "index=" + index +
          ", difference=" + difference +
          '}';
      }
    }
  }
}