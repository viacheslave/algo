package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Bipartite-Graph
 * Submission: https://binarysearch.com/problems/Bipartite-Graph/submissions/7022823
 */
public class P0045 {
  class Solution {
    public boolean solve(int[][] graph) {
      var colors = new HashMap<Integer, Integer>();

      // BFS
      var visited = new HashSet<Integer>();
      var available = new TreeSet<Integer>();
      for (int i = 0; i < graph.length; i++) {
        available.add(i);
      }

      var queue = new LinkedList<Colored>();
      queue.add(new Colored(0, 0));

      visited.add(0);
      available.remove(0);
      colors.put(0, 0);

      while (!queue.isEmpty()) {
        var el = queue.poll();
        var color = 1 - el.color;

        for (var ee : graph[el.id]) {
          if (!visited.contains(ee)) {
            visited.add(ee);
            available.remove(ee);
            colors.put(ee, color);

            queue.add(new Colored(ee, color));
            continue;
          }

          if (colors.get(ee) != color)
            return false;
        }

        if (queue.isEmpty() && !available.isEmpty()) {
          var item = available.first();

          queue.add(new Colored(item, 0));

          visited.add(item);
          available.remove(item);
          colors.put(item, 0);
        }
      }

      return true;
    }

    public class Colored {
      public int id;
      public int color;

      public Colored (int id, int color) {
        this.id = id;
        this.color = color;
      }
    }
  }
}