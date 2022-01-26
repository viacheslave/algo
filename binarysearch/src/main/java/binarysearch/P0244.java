package binarysearch;

import java.util.*;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Course-Scheduling
 * Submission: https://binarysearch.com/problems/Course-Scheduling/submissions/7380643
 */
public class P0244 {
  class Solution {
    public boolean solve(int[][] courses) {
      var adj = new HashMap<Integer, List<Integer>>();
      var indegrees = new HashMap<Integer, Integer>();

      for (var i = 0; i < courses.length; i++) {
        indegrees.putIfAbsent(i, 0);
        adj.putIfAbsent(i, new ArrayList<>());

        for (int j = 0; j < courses[i].length; j++) {
          adj.putIfAbsent(courses[i][j], new ArrayList<>());
          adj.get(courses[i][j]).add(i);

          indegrees.put(i, indegrees.getOrDefault(i, 0) + 1);
        }
      }

      var queue = new LinkedList<Integer>();
      for (var e : indegrees.entrySet()) {
        if (e.getValue() == 0)
          queue.offer(e.getKey());
      }

      while (!queue.isEmpty()) {
        var node = queue.poll();

        for (var a: adj.get(node)) {
          indegrees.put(a, indegrees.get(a) - 1);
          if (indegrees.get(a) == 0) {
            queue.offer(a);
          }
        }
      }

      return indegrees.values().stream().allMatch(x -> x == 0);
    }
  }
}