package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/number-of-wonderful-substrings/
 * Submission: https://leetcode.com/submissions/detail/588723382/
 */
public class P1915 {
  class Solution {
    public long wonderfulSubstrings(String word) {
      var masks = new int[word.length()];

      var map = new HashMap<Integer, Integer>();
      for (int i = 0; i < 10; i++) {
        map.put(i, 0);
      }

      // create prefix bitmasks
      // a..j is 10 bits
      for (int i = 0; i < word.length(); i++) {
        var index = word.charAt(i) - 97;
        map.put(index, map.get(index) + 1);

        var value = 0;
        for (int k = 0; k < 10; k++) {
          if (map.get(k) % 2 == 1)
            value += Math.pow(2, k);
        }

        masks[i] = value;
      }

      var ans = 0L;

      // create counting map
      var mp = Arrays.stream(masks).boxed()
        .collect(Collectors.groupingBy(x -> x, Collectors.counting()));

      for (var m : mp.entrySet()) {
        // each symbol is eligible
        if (atMostOneOdd(m.getKey())) {
          ans += m.getValue();
        }

        // all combinations of each symbol
        // aa, aaa
        ans += (m.getValue() - 1) * m.getValue() / 2;
      }

      var mpKeys = new ArrayList<Integer>(mp.keySet());

      // all cross combinations of masks
      for (int i = 0; i < mpKeys.size() - 1; i++) {
        for (int j = i + 1; j < mpKeys.size(); j++) {
          if (atMostOneOdd((mpKeys.get(i) ^ mpKeys.get(j)))) {
            ans += mp.get(mpKeys.get(i)) * mp.get(mpKeys.get(j));
          }
        }
      }

      return ans;
    }

    private boolean atMostOneOdd(long mask) {
      return (mask & (mask - 1)) == 0;
    }
  }
}