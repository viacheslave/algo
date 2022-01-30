package com.vzh.leetcode;

import java.util.*;
import java.util.stream.Collectors;

/**
 * Problem: https://leetcode.com/problems/groups-of-strings/
 * Submission: https://leetcode.com/submissions/detail/631164503/
 */
public class P2157 {
  class Solution {
    public int[] groupStrings(String[] words) {
      var wordsCounting = Arrays
        .stream(words)
        .map(this::toInt)
        .collect(Collectors.groupingBy(x -> x, Collectors.counting()));

      var adjList = new HashMap<Integer, Set<Integer>>();

      for (var w : wordsCounting.keySet()) {
        adjList.putIfAbsent(w, new HashSet<>());

        // for every letter
        // add it or remove it
        for (var i = 0; i < 26; i++) {
          var value = 0;
          var pow = (1 << i);
          if ((w & (1 << i)) == (1 << i)) // 1
            value = w - pow;
          else
            value = w + pow;

          if (wordsCounting.containsKey(value)) {
            adjList.get(w).add(value);
          }
        }

        var digits = new int[26];

        for (var j = 0; j < 26; j++) {
          if ((w & (1 << j)) == (1 << j))
            digits[j] = 1;
        }

        var ones = new ArrayList<Integer>();
        var zeros = new ArrayList<Integer>();

        for (var j = 0; j < 26; j++) {
          if (digits[j] == 0) zeros.add(j);
          else ones.add(j);
        }

        for (Integer zero : zeros) {
          for (Integer one : ones) {
            var value = w + (1 << zero) - (1 << one);
            if (wordsCounting.containsKey(value)) {
              adjList.get(w).add(value);
            }
          }
        }
      }

      var groups = new ArrayList<Long>();

      // dfs
      var visited = new HashSet<Integer>();
      for (var node : adjList.keySet()) {
        var local = new HashSet<Integer>();

        if (!visited.contains(node)) {
          dfs(adjList, node, local);

          var sum = local.stream().map(wordsCounting::get)
            .mapToLong(x -> x).sum();

          groups.add(sum);
          visited.addAll(local);
        }
      }

      return new int[] {
        groups.size(),
        groups.stream().max(Comparator.naturalOrder()).get().intValue() };
    }

    private void dfs(HashMap<Integer, Set<Integer>> adjList, Integer node, HashSet<Integer> local) {
      local.add(node);
      for (var next : adjList.get(node)) {
        if (local.contains(next))
          continue;
        dfs(adjList, next, local);
      }
    }

    private Integer toInt(String x) {
      return x.chars()
        .reduce(0, (a, b) -> a += (1 << (b - 'a')));
    }
  }
}
