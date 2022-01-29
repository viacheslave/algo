package binarysearch;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;

/*
 * Problem: https://binarysearch.com/problems/Longest-Distinct-Sublist
 * Submission: https://binarysearch.com/problems/Longest-Distinct-Sublist/submissions/7406564
 */
public class P0118 {
  class Solution {
    public int solve(int[] nums) {
      if (nums.length == 0)
        return 0;

      var left = 0;
      var right = 0;

      var ans = 1;
      var count = 1;
      var map = new HashMap<Integer, Integer>();

      // sliding window
      while (right < nums.length) {
        if (map.containsKey(nums[right])) {
          count++;
          map.put(nums[right], map.get(nums[right]) + 1);
        }
        else {
          map.put(nums[right], 1);
        }

        if (count == 1) {
          ans = Math.max(ans, right - left + 1);

          right++;
          continue;
        }

        while (count > 1) {
          map.put(nums[left], map.get(nums[left]) - 1);
          if (map.get(nums[left]) == 1) {
            count--;
          }
          else if (map.get(nums[left]) == 0) {
            map.remove(nums[left]);
          }

          left++;
        }

        right++;
      }

      return ans;
    }
  }
}