package binarysearch;

import java.util.Arrays;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Sum-Pairs-to-Target
 * Submission: https://binarysearch.com/problems/Sum-Pairs-to-Target/submissions/6656427
 */
public class P0836 {
  class Solution {
    public int solve(int[] nums, int target) {
      var map = Arrays.stream(nums)
        .boxed()
        .collect(Collectors.groupingBy(x -> x, Collectors.counting()));

      var ans = 0;

      var keys = map.keySet().stream().mapToInt(x -> x).toArray();

      for (var key : keys) {
        if (map.containsKey(key) && map.containsKey(target - key)) {
          if (key == target - key) {
            ans += map.get(key) / 2;
            map.remove(key);
            continue;
          }

          ans += Math.min(map.get(key), map.get(target - key));
          map.remove(key);
          map.remove(target - key);
        }
      }

      return ans;
    }
  }
}