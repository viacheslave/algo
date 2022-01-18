package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/course-schedule-iv/
 * Submission: https://leetcode.com/submissions/detail/589026402/
 */
public class P1462 {
  class Solution {
    public List<Boolean> checkIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
      var arr = new int[numCourses][numCourses];
      var dependencies = new HashMap<Integer, ArrayList<Integer>>();

      // build hashmap of dependencies
      for (int i = 0; i < numCourses; i++) {
        dependencies.putIfAbsent(i, new ArrayList<>());
      }

      for (var prer: prerequisites) {
        dependencies.get(prer[0]).add(prer[1]);
      }

      // BFS
      // traverse from each node to every other node
      // and fill reachable array
      for (var i = 0; i < numCourses; i++) {
        var visited = new HashSet<Integer>();
        var queue = new LinkedList<Integer>();
        queue.add(i);

        while (!queue.isEmpty()) {
          var el = queue.poll();

          for (var dep : dependencies.get(el)) {
            arr[i][dep] = 1;

            if (visited.contains(dep))
              continue;

            queue.add(dep);
            visited.add(dep);
          }
        }
      }

      var ans = new ArrayList<Boolean>();

      for (var query : queries) {
        var value = arr[query[0]][query[1]] == 1;
        ans.add(value);
      }

      return ans;
    }
  }
}