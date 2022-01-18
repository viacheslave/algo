package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/minimum-garden-perimeter-to-collect-enough-apples/
 * Submission: https://leetcode.com/submissions/detail/532773825/
 */
public class P1954 {
  class Solution {
    public long minimumPerimeter(long neededApples) {
      var memo = new ArrayList<Long>();
      memo.add(0L);

      var side = 1;
      while (true) {
        var apples = getApples(side);
        apples += memo.get(side - 1);

        if (apples >= neededApples)
          break;

        memo.add(apples);
        side++;
      }

      return side * 4;
    }

    private long getApples(long side) {
      if (side % 2 == 1)
        return 0;

      var half = side / 2;

      var sum = (half + 1) * (half + 1 + 1) / 2 + (half - 1) * (half + 1);
      sum = sum * 8;
      sum -= half * 4;
      sum -= half * 2 * 4;
      return sum;
    }
  }
}