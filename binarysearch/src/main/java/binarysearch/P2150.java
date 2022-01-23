
package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/find-all-lonely-numbers-in-the-array/submissions/
 * Submission: https://leetcode.com/submissions/detail/625903851/
 */
public class P2150 {
  class Solution {
    public List<Integer> findLonely(int[] nums) {
      var map = Arrays.stream(nums).boxed()
        .collect(Collectors.groupingBy(x -> x, Collectors.counting()));

      var arr = new ArrayList<Integer>();;

      for (int num : nums) {
        if (map.get(num) == 1 && !map.containsKey(num - 1) && !map.containsKey(num + 1)) {
          arr.add(num);
        }
      }

      return arr;
    }
  }
}