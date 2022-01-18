package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/painting-a-grid-with-three-different-colors/
 * Submission: https://leetcode.com/submissions/detail/589614445/
 */
public class P1931 {
  class Solution {
    public int colorTheGrid(int m, int n) {
      var mod = (int)1e9 + 7;

      // generate all valid rows
      // max length of m
      var arr = new int[m];
      var rows = new ArrayList<Integer>();

      generateCombinations(rows, arr, 0, m);

      // generate combination pairs
      // two bitmasks should give 0 on &&
      var combinations = new HashSet<Pair>();

      for (var a1 : rows)
        for (var a2: rows)
          if ((a1 & a2) == 0)
            combinations.add(new Pair(a1, a2));

      // DP over rows
      var dp = new HashMap<Key, Integer>();
      for (var row : rows) {
        dp.put(new Key(0, row), 1);
      }

      for (var r = 1; r < n; r++) {
        for (var co : combinations) {
          var v = dp.get(new Key(r - 1, co.item1));
          var key = new Key(r, co.item2);

          dp.putIfAbsent(key, 0);
          dp.put(key, (dp.get(key) + v) % mod);
        }
      }

      // sum all variants of the last row
      var ans = 0;
      for (var i : dp.entrySet()) {
        if (i.getKey().row == n - 1) {
          ans += i.getValue();
          ans %= mod;
        }
      }

      return ans;
    }

    private void generateCombinations(ArrayList<Integer> rows, int[] arr, int index, int m) {
      if (index == m) {
        var value = 0;

        for (var i = 0; i < arr.length; i++) {
          value += (int)Math.pow(2, 4 * i + (arr[i]));
        }

        rows.add(value);
        return;
      }

      for (var k = 0; k < 3; k++) {
        if (index != 0 && k == arr[index - 1])
          continue;

        arr[index] = k;
        generateCombinations(rows, arr, index + 1, m);
        arr[index] = 0;
      }
    }

    public class Key {
      public int row;
      public int value;

      public Key(int row, int value) {
        this.row = row;
        this.value = value;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Key key = (Key) o;
        return row == key.row && value == key.value;
      }

      @Override
      public int hashCode() {
        return Objects.hash(row, value);
      }

      @Override
      public String toString() {
        return "Key{" +
          "row=" + row +
          ", value=" + value +
          '}';
      }
    }

    public class Pair {
      public int item1;
      public int item2;

      public Pair(int item1, int item2) {
        this.item1 = item1;
        this.item2 = item2;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Pair pair = (Pair) o;
        return item1 == pair.item1 && item2 == pair.item2;
      }

      @Override
      public int hashCode() {
        return Objects.hash(item1, item2);
      }
    }
  }
}