package com.vzh.leetcode;

import java.util.ArrayList;
import java.util.PriorityQueue;

/*
 * Problem: https://leetcode.com/problems/longest-happy-string/
 * Submission: https://leetcode.com/submissions/detail/586141336/
 */
public class P1405 {
  class Solution {
    public String longestDiverseString(int a, int b, int c) {
      var queue = new PriorityQueue<Item>((o1, o2) -> o2.count - o1.count);

      if (a > 0)
        queue.add(new Item('a', a));
      if (b > 0)
        queue.add(new Item('b', b));
      if (c > 0)
        queue.add(new Item('c', c));

      var sb = new StringBuilder();

      var ch = 'a';
      var count = 0;
      var items = new ArrayList<Item>();

      while (!queue.isEmpty()) {
        var item = queue.poll();
        if (item.ch == ch && count == 2) {
          items.add(item);
          continue;
        }

        sb.append(item.ch);
        if (item.ch == ch) {
          count++;
        } else {
          ch = item.ch;
          count = 1;
        }

        queue.addAll(items);
        items.clear();

        if (item.count != 1)
          queue.add(new Item(item.ch, item.count - 1));
      }

      return sb.toString();
    }

    public class Item {
      public char ch;
      public int count;

      public Item(char ch, int count) {
        this.ch = ch;
        this.count = count;
      }
    }
  }
}