package com.vzh.leetcode;

import java.util.Arrays;
import java.util.Comparator;
import java.util.HashMap;
import java.util.TreeMap;

/**
 * Problem: https://leetcode.com/problems/maximum-white-tiles-covered-by-a-carpet/
 * Submission: https://leetcode.com/submissions/detail/699893026/
 */
public class P2271 {
  class Solution {
    public int maximumWhiteTiles(int[][] tiles, int carpetLen) {
      Arrays.sort(tiles, Comparator.comparingInt(x -> x[0]));

      var prefixSums = new int[tiles.length + 1];
      for (var i = 0; i < tiles.length; i++) {
        prefixSums[i + 1] = prefixSums[i] + (tiles[i][1] - tiles[i][0] + 1);
      }

      // build map
      var treeMap = new TreeMap<Integer, Integer>();
      var order = new HashMap<Integer, Integer>();

      for (var i = 0; i < tiles.length; i++) {
        treeMap.put(tiles[i][0], tiles[i][1]);
        order.put(tiles[i][0], i);
      }

      var ans = Integer.MIN_VALUE;

      // the optimal location of the carpet is at the beginning
      // of the tile
      for (var i = 0; i < tiles.length; i++) {
        var start = tiles[i][0];
        var end = start + carpetLen - 1;

        var floor = treeMap.floorKey(end);
        var tail = Math.min(treeMap.get(floor) - floor + 1, start + carpetLen - floor);
        var head = 0;

        if (floor != start) {
          var rightIndex = order.get(floor) - 1;
          var leftIndex = order.get(start);
          head = prefixSums[rightIndex + 1] - prefixSums[leftIndex];
        }

        var crosses = head + tail;

        ans = Math.max(ans, crosses);
      }

      return ans;
    }
  }
}
