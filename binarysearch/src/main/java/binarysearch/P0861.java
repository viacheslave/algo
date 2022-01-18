package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashSet;

/*
 * Problem: https://binarysearch.com/problems/Maximize-Roster-Rating
 * Submission: https://binarysearch.com/problems/Maximize-Roster-Rating/submissions/7108542
 */
public class P0861 {
  class Solution {
    public int solve(int[] ratings, int[] ages) {
      var data = new ArrayList<Pair>();

      for (int i = 0; i < ratings.length; i++) {
        data.add(new Pair(ratings[i], ages[i]));
      }

      Collections.sort(data);

      // ratings list from sorted by age
      var list = data.stream().mapToInt(Pair::getRating).toArray();

      // DP based on LIS
      var dp = new int[list.length];

      for (int i = 0; i < list.length; i++) {
        dp[i] = list[i];

        for (int j = 0; j < i; j++) {
          if (list[j] <= list[i]) {
            dp[i] = Math.max(dp[i], dp[j] + list[i]);
          }
        }
      }

      return Arrays.stream(dp).max().getAsInt();
    }

    class Pair implements Comparable<Pair> {
      public int rating;
      public int age;

      public int getRating() {
        return this.rating;
      }

      public Pair(int rating, int age) {
        this.age = age;
        this.rating = rating;
      }

      @Override
      public int compareTo(Pair o) {
        if (this.age == o.age) {
          return this.rating - o.rating;
        }
        return this.age - o.age;
      }
    }
  }
}