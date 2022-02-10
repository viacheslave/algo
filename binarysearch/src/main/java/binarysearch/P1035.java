package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

/*
 * Problem: https://binarysearch.com/problems/Distance-Sums
 * Submission: https://binarysearch.com/problems/Distance-Sums/submissions/7517604
 */
public class P1035 {
  class Solution {
    public int[] solve(int[] nums) {
      //1 2 3
      //  1 2

      var indexMap = new HashMap<Integer, List<Integer>>();
      for (int i = 0; i < nums.length; i++) {
        indexMap.putIfAbsent(nums[i], new ArrayList<>());
        indexMap.get(nums[i]).add(i);
      }

      var distances = new HashMap<Integer, List<Integer>>();

      for (var e : indexMap.entrySet()) {
        if (e.getValue().size() == 1)
          continue;;

        var diffs = new ArrayList<Integer>();
        for (int i = 1; i < e.getValue().size(); i++) {
          diffs.add(e.getValue().get(i) - e.getValue().get(i - 1));
        }

        var sums = new int[diffs.size()];
        for (int i = 0; i < diffs.size(); i++) {
          if (i == 0) {
            sums[0] = diffs.get(i);
          }
          else {
            sums[i] = diffs.get(i) + sums[i - 1];
          }
        }

        var sum = Arrays.stream(sums).sum();

        var distance = new ArrayList<Integer>();

        var left = 0;
        var right = sum;
        distance.add(left + right);

        for (var i = 1; i < e.getValue().size(); i++) {
          var d = e.getValue().get(i) - e.getValue().get(i - 1);
          left += i * d;
          right -= (e.getValue().size() - i) * d;
          distance.add(left + right);
        }

        distances.put(e.getKey(), distance);
      }

      var ans = new int[nums.length];

      for (var d : distances.entrySet()) {
        for (var i = 0; i < d.getValue().size(); i++) {
          ans[indexMap.get(d.getKey()).get(i)] = d.getValue().get(i);
        }
      }

      return ans;
    }
  }
}