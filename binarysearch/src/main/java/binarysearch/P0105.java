package binarysearch;

import java.util.ArrayList;
import java.util.HashMap;

/*
 * Problem: https://binarysearch.com/problems/Add-Binary-Numbers
 * Submission: https://binarysearch.com/problems/Add-Binary-Numbers/submissions/6646600
 */
public class P0105 {
  class Solution {
    public int[] solve(int[] nums) {
      var set = new HashMap<Integer, Integer>();

      for (int i = 0; i < nums.length; i++) {
        set.putIfAbsent(nums[i], 0);
        set.put(nums[i], set.get(nums[i]) + 1);
      }

      var arr = new ArrayList<Integer>();
      for (int i = 0; i < nums.length; i++) {
        if (set.get(nums[i]) == 1)
          arr.add(nums[i]);
      }

      return arr.stream().mapToInt(x -> x).toArray();
    }
  }
}