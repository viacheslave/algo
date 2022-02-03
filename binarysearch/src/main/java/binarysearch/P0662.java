package binarysearch;

import java.util.HashMap;
import java.util.Objects;

/*
 * Problem: https://binarysearch.com/problems/Maximum-Additive-Score-by-Removing-Numbers
 * Submission: https://binarysearch.com/problems/Maximum-Additive-Score-by-Removing-Numbers/submissions/7457638
 */
public class P0662 {
  class Solution {
    public int solve(int[] nums) {
      var n = nums.length;
      var dp = new HashMap<Pair, Integer>();

      var ans = recursive(nums, dp, 1, n - 2);

      return ans;
    }

    private int recursive(int[] nums, HashMap<Pair, Integer> dp, int start, int end) {
      if (start > end)
        return 0;

      if (dp.containsKey(new Pair(start, end)))
        return dp.get(new Pair(start, end));

      if (start == end)
        return nums[start] + nums[start - 1] + nums[start + 1];

      var max = 0;

      for (var i = start; i <= end; i++) {
        var left = recursive(nums, dp, start, i - 1);
        var right = recursive(nums, dp, i + 1, end);

        max = Math.max(max,
          nums[i] + nums[start - 1] + nums[end + 1] + left + right);
      }

      dp.put(new Pair(start, end), max);
      return max;
    }

    private static class Pair {
      public int item1;
      public int item2;

      public Pair(int item1, int item2) {
        this.item1 = item1;
        this.item2 = item2;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Pair pair = (Pair) o;
        return item1 == pair.item1 && item2 == pair.item2;
      }

      @Override
      public int hashCode() {
        return Objects.hash(item1, item2);
      }
    }
  }
}