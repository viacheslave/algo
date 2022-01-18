package com.vzh.leetcode;

import java.util.Arrays;
import java.util.HashSet;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid/
 * Submission: https://leetcode.com/submissions/detail/571317743/
 */
public class P2034 {
  class StockPrice {

    private TreeMap<Integer, Integer> timestampToPrice = new TreeMap<>();
    private TreeMap<Integer, HashSet<Integer>> priceToTimestamps = new TreeMap<>();

    public StockPrice() {
    }

    public void update(int timestamp, int price) {
      var previousPrice = timestampToPrice.get(timestamp);

      timestampToPrice.put(timestamp, price);

      // remove from existing
      if (previousPrice != null && priceToTimestamps.containsKey(previousPrice)) {
        var entry = priceToTimestamps.get(previousPrice);
        entry.remove(timestamp);

        if (entry.isEmpty())
          priceToTimestamps.remove(previousPrice);
      }

      // add to new
      priceToTimestamps.putIfAbsent(price, new HashSet<>());
      priceToTimestamps.get(price).add(timestamp);
    }

    public int current() {
      return timestampToPrice.lastEntry().getValue();
    }

    public int maximum() {
      return priceToTimestamps.lastKey();
    }

    public int minimum() {
      return priceToTimestamps.firstKey();
    }
  }
}