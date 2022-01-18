package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

/*
 * Problem: https://leetcode.com/problems/rings-and-rods/
 * Submission: https://leetcode.com/submissions/detail/601859034/
 */
public class P2103 {
  class Solution {
    public int countPoints(String rings) {

      var map = new HashMap<Integer, HashSet<Character>>();

      for (int i = 0; i < rings.length(); i += 2) {
        var color = rings.charAt(i);
        var rod = rings.charAt(i + 1);

        var key = Integer.valueOf(String.valueOf(rod));

        map.putIfAbsent(key, new HashSet<>());
        map.get(key).add(color);
      }

      return (int) map.values().stream().filter(x -> x.size() == 3).count();
    }
  }
}