package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Kth-Missing-Number
 * Submission: https://binarysearch.com/problems/Kth-Missing-Number/submissions/6828786
 */
public class P0588 {
  class Solution {
    public int solve(int[] nums, int k) {
      var pairs = new ArrayList<Pair>();

      for (int i = 0; i < nums.length - 1; i++) {
        if (nums[i + 1] - nums[i] > 1) {
          pairs.add(new Pair(nums[i] + 1, nums[i + 1] - 1));
        }
      }

      if (nums[nums.length - 1] != 100_000) {
        pairs.add(new Pair(nums[nums.length - 1] + 1, 100_000));
      }

      var index = 0;
      var ranges = new ArrayList<Pair>();
      for (int i = 0; i < pairs.size(); i++) {
        var end = index + pairs.get(i).to - pairs.get(i).from;
        ranges.add(new Pair(index, end));
        index = end + 1;
      }

      // binary search
      var left = 0;
      var right = ranges.size() - 1;
      Pair range;

      while (true) {
        if (right - left < 2) {
          var r = ranges.get(left);
          if (r.from <= k && k <= r.to) {
            range = r;
            index = left;
            break;
          }
          else {
            range = ranges.get(right);
            index = right;
            break;
          }
        }

        var mid = (left + right) / 2;

        var r = ranges.get(mid);
        if (r.from <= k && k <= r.to) {
          range = r;
          index = mid;
          break;
        }

        if (k < r.from)
          right = mid;
        else
          left = mid;
      }

      return pairs.get(index).from + k - range.from;
    }

    public class Pair {
      public int from;
      public int to;

      public Pair(int from, int to) {
        this.from = from;
        this.to = to;
      }
    }
  }
}