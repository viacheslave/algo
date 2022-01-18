
package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.HashMap;

/*
 * Problem: https://leetcode.com/problems/range-frequency-queries/
 * Submission: https://leetcode.com/submissions/detail/590561124/
 */
public class P2080 {
  class RangeFreqQuery {

    private HashMap<Integer, ArrayList<Integer>> map;

    public RangeFreqQuery(int[] arr) {
      map = new HashMap<>();

      for (int i = 0; i < arr.length; i++) {
        map.putIfAbsent(arr[i], new ArrayList<>());
        map.get(arr[i]).add(i);
      }
    }

    public int query(int left, int right, int value) {
      if (!map.containsKey(value))
        return 0;

      var set = map.get(value);

      var l = getLeft(map.get(value), left);
      var r = getRight(map.get(value), right);

      if (l == -1 || r == -1 || l > r)
        return 0;

      return r - l + 1;
    }

    private int getLeft(ArrayList<Integer> integers, int target) {
      var s = 0;
      var e = integers.size() - 1;

      while (true) {
        if (e - s < 2) {
          if (target <= integers.get(s))
            return s;
          if (target <= integers.get(e))
            return e;
          return -1;
        }

        var mid = (s + e) >> 1;
        if (integers.get(mid) < target)
          s = mid;
        else
          e = mid;
      }
    }

    private int getRight(ArrayList<Integer> integers, int target) {
      var s = 0;
      var e = integers.size() - 1;

      while (true) {
        if (e - s < 2) {
          if (target >= integers.get(e))
            return e;
          if (target >= integers.get(s))
            return s;
          return -1;
        }

        var mid = (s + e) >> 1;
        if (integers.get(mid) > target)
          e = mid;
        else
          s = mid;
      }
    }
  }
}