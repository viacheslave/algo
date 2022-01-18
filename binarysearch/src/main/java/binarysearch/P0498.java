package binarysearch;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedList;

/*
 * Problem: https://binarysearch.com/problems/K-Distinct-Window
 * Submission: https://binarysearch.com/problems/K-Distinct-Window/submissions/7305156
 */
public class P0498 {
  class Solution {
    public int[] solve(int[] nums, int k) {
      var map = new HashMap<Integer, Integer>();

      for (int i = 0; i < k; i++) {
        map.put(nums[i], map.getOrDefault(nums[i], 0) + 1);
      }

      var ans = new ArrayList<Integer>();
      ans.add(map.size());

      for (var i = k; i < nums.length; i++) {
        map.put(nums[i], map.getOrDefault(nums[i], 0) + 1);
        map.put(nums[i - k], map.get(nums[i - k]) - 1);
        if (map.get(nums[i - k]) == 0) {
          map.remove(nums[i - k]);
        }

        ans.add(map.size());
      }

      return ans.stream().mapToInt(x -> x).toArray();
    }
  }
}
