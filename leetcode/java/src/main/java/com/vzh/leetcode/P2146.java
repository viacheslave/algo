package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/k-highest-ranked-items-within-a-price-range/
 * Submission: https://leetcode.com/submissions/detail/625325535/
 *
 * Do BFS. Stop early at distance.
 * Put results into a priority queue.
 */
class P2146 {
  class Solution {
    public List<List<Integer>> highestRankedKItems(int[][] grid, int[] pricing, int[] start, int k) {
      var n = grid.length;
      var m = grid[0].length;

      var low = pricing[0];
      var high = pricing[1];

      var queue = new LinkedList<Item>();
      queue.offer(new Item(0, grid[start[0]][start[1]], start[0], start[1]));

      var visited = new HashSet<Pair>();
      visited.add(new Pair(start[0], start[1]));

      var pq = new PriorityQueue<Item>((a, b) -> {
        if (a.distance != b.distance) {
          return a.distance - b.distance;
        }

        if (a.price != b.price) {
          return a.price - b.price;
        }

        if (a.row != b.row) {
          return a.row - b.row;
        }

        return a.col - b.col;
      });

      var dx = new int[] {0,1,0,-1};
      var dy = new int[] {-1,0,1,0};

      var distance = 0;

      while (!queue.isEmpty()) {
        var el = queue.poll();

        if (distance < el.distance && pq.size() >= k)
          break;

        distance = el.distance;

        if (low <= el.price && el.price <= high) {
          pq.add(el);
        }

        for (var i = 0; i < 4; i++) {
          var px = el.row + dx[i];
          var py = el.col + dy[i];

          if (px < 0 || py < 0 || px >= n || py >= m) {
            continue;
          }

          if (visited.contains(new Pair(px, py)))
            continue;

          if (grid[px][py] == 0)
            continue;

          visited.add(new Pair(px, py));
          queue.add(new Item(el.distance + 1, grid[px][py], px, py));
        }
      }

      var ans = new ArrayList<List<Integer>>();

      for (int i = 0; i < k; i++) {
        if (pq.isEmpty())
          break;

        var item = pq.poll();
        ans.add(List.of(item.row, item.col));
      }

      return ans;
    }

    public class Item {
      public int distance;
      public int price;
      public int row;
      public int col;

      public Item(int distance, int price, int row, int col) {
        this.distance = distance;
        this.price = price;
        this.row = row;
        this.col = col;
      }
    }

    public class Pair {
      public int x;
      public int y;

      public Pair (int x, int y) {
        this.x = x;
        this.y = y;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Pair pair = (Pair) o;
        return x == pair.x && y == pair.y;
      }

      @Override
      public int hashCode() {
        return Objects.hash(x, y);
      }
    }
  }
}

