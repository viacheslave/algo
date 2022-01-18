package com.vzh.leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/cracking-the-safe/
 * Submission: https://leetcode.com/submissions/detail/597423046/
 */
public class P0753 {
  class Solution {
    public String crackSafe(int n, int k) {

      if (k == 1) {
        var ch = new char[n];
        Arrays.fill(ch, '0');
        return String.valueOf(ch);
      }

      // generate vertices
      var vertices = generate(n, k);

      // get graph
      var adjList = getAdjList(vertices, k);

      // calculate ins and outs
      var out = new HashMap<String, Integer>();
      var in = new HashMap<String, Integer>();

      for (var entry : adjList.entrySet()) {
        var v = entry.getKey();
        var next = entry.getValue();
        out.put(v, next.size());
        for (String ns : next) {
          in.put(ns, in.getOrDefault(ns, 0) + 1);
        }
      }

      // find start node for euclidian path
      var startCh = findStart(vertices, out, in);

      var start = String.valueOf(startCh);
      var path = new ArrayList<String>();
      var visited = new HashSet<String>();

      // dfs with visited
      dfs(start, path, out, adjList, visited);

      var ans = new StringBuilder(path.get(path.size() - 1));

      for (var i = path.size() - 2; i >= 0; i--) {
        ans.append(path.get(i).charAt(path.get(i).length() - 1));
      }

      return ans.toString();
    }

    private void generate(int n, int k, char[] buffer, int index, ArrayList<String> ret) {
      if (n == index) {
        ret.add(String.valueOf(buffer));
        return;
      }

      for (var i = 0; i < k; i++) {
        buffer[index] = (char)(i + 48);
        generate(n, k, buffer, index + 1, ret);
      }
    }

    private String findStart(List<String> vertices, HashMap<String, Integer> out, HashMap<String, Integer> in) {
      int index = 0;
      for (int i = 0; i < vertices.size(); i++) {
        if (out.get(vertices.get(i)) - in.get(vertices.get(i)) == 1)
          return vertices.get(i);
        if (out.get(vertices.get(i)) > 0)
          index = i;
      }
      return vertices.get(index);
    }

    private HashMap<String, List<String>> getAdjList(List<String> vertices, int k) {
      var map = new HashMap<String, List<String>>();

      for (var v : vertices) {
        var sb = new StringBuilder(v);
        sb.deleteCharAt(0);
        sb.append('X');

        var us = new ArrayList<String>();

        for (var i = 0; i < k; i++) {
          sb.setCharAt(sb.length() - 1, (char)( i + 48) );
          var u = sb.toString();

          if (!v.equals(u)) {
            us.add(u);
          }
        }

        map.put(v, us);
      }

      return map;
    }

    private void dfs(String at, ArrayList<String> path, HashMap<String, Integer> out, HashMap<String, List<String>> map, HashSet<String> visited) {
      if (visited.contains(at))
        return;;

      visited.add(at);

      while (out.get(at) != 0) {
        out.put(at, out.get(at) - 1);
        var next = map.get(at).get(out.get(at));
        dfs(next, path, out, map, visited);
      }

      path.add(at);
    }

    private List<String> generate(int n, int k) {
      var ret = new ArrayList<String>();
      var buffer = new char[n];
      generate(n, k, buffer, 0, ret);

      return ret;
    }
  }
}