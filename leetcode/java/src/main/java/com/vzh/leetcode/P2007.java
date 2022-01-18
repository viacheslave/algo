package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/find-original-array-from-doubled-array/
 * Submission: https://leetcode.com/submissions/detail/557453046/
 */
public class P2007 {
  class Solution {
    public int[] findOriginalArray(int[] changed) {
      if (changed.length % 2 == 1)
        return new int[0];

      var tm = new TreeMap<Integer, Integer>();

      for (int i = 0; i < changed.length; i++) {
        if (tm.containsKey(changed[i]))
          tm.replace(changed[i], tm.get(changed[i]) + 1);
        else
          tm.put(changed[i], 1);
      }

      var ans = new ArrayList<Integer>();

      while (tm.size() > 0) {
        var entry = tm.firstEntry();
        var k = entry.getKey();
        var v = entry.getValue();

        if (tm.containsKey(k * 2)) {
          if (k == 0) {
            if (tm.get(k) == 1)
              return new int[0];

            tm.put(k, v - 2);
            if (v == 2)
              tm.remove(k);

            ans.add(0);
            continue;
          }

          var doubledEntry = tm.get(k * 2);

          tm.put(k, v - 1);
          tm.put(k * 2, doubledEntry - 1);

          if (tm.get(k) == 0)
            tm.remove(k);
          if (tm.get(k * 2) == 0)
            tm.remove(k * 2);

          ans.add(k);
        } else {
          return new int[0];
        }
      }

      return ans.stream().mapToInt(x -> x).toArray();
    }
  }
}