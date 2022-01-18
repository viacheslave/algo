package binarysearch;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.TreeMap;

/*
 * Problem: https://binarysearch.com/problems/Unlock-Rooms
 * Submission: https://binarysearch.com/problems/Unlock-Rooms/submissions/6960229
 */
public class P0621 {
  class Solution {
    public boolean solve(int[][] rooms) {
      // DFS

      var visited = new HashSet<Integer>();
      var queue = new LinkedList<Integer>();
      queue.add(0);

      while (!queue.isEmpty()) {
        var el = queue.poll();
        if (visited.contains(el))
          continue;

        visited.add(el);

        for (var room : rooms[el])
          queue.add(room);
      }

      return visited.size() == rooms.length;
    }
  }
}