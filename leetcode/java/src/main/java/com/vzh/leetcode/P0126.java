package com.vzh.leetcode;

import java.util.*;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/word-ladder-ii/
 * Submission: https://leetcode.com/submissions/detail/635872063/
 */
public class P0126 {
  class Solution {
    public List<List<String>> findLadders(String beginWord, String endWord, List<String> wordList) {
      var wordSet = wordList.stream().collect(Collectors.toSet());
      if (!wordList.contains(endWord)) {
        return new ArrayList<>();
      }

      wordSet.add(beginWord);

      var words = wordSet.stream().collect(Collectors.toList());
      var wordLength = beginWord.length();
      var startIndex = words.indexOf(beginWord);
      var endIndex = words.indexOf(endWord);

      // calculate adjList
      // and create a graph beforehand
      var adjList = new HashMap<Integer, List<Integer>>();

      for (int i = 0; i < words.size(); i++) {
        adjList.put(i, new ArrayList<>());
      }

      for (int i = 0; i < words.size() - 1; i++) {
        for (int j = i + 1; j < words.size(); j++) {
          if (oneOff(words, i, j, wordLength)) {
            adjList.get(i).add(j);
            adjList.get(j).add(i);
          }
        }
      }

      // bfs
      // find shortest length
      var queue = new LinkedList<QI>();
      var visited = new int[words.size()];

      queue.offer(new QI(startIndex, 0));
      visited[startIndex] = 1;

      var shortest = Integer.MAX_VALUE;

      while (!queue.isEmpty()) {
        var el = queue.poll();
        if (el.index == endIndex) {
          shortest = el.length;
          break;
        }

        for (var i = 0; i < adjList.get(el.index).size(); i++) {
          var item = adjList.get(el.index).get(i);
          if (visited[item] == 0) {
            visited[item] = 1;
            queue.offer(new QI(item, el.length + 1));
          }
        }
      }

      // now split path in half
      // go forward and backward
      // find meeting indices that equal

      // forward
      var forward = new ArrayList<List<Integer>>();
      var forwardLength = shortest / 2;
      var stack = new Stack<Integer>();

      stack.push(startIndex);
      Arrays.fill(visited, 0);
      visited[startIndex] = 1;

      dfs(startIndex, stack, forward, 0, forwardLength, visited, wordLength, adjList);

      // backward
      var backward = new ArrayList<List<Integer>>();
      var backwardLength = shortest - shortest / 2;
      stack = new Stack<Integer>();

      stack.push(endIndex);
      Arrays.fill(visited, 0);
      visited[endIndex] = 1;

      dfs(endIndex, stack, backward, 0, backwardLength, visited, wordLength, adjList);

      // create maps by last index
      var forwardMap = forward.stream()
        .map(x -> new Meeting(x.get(forwardLength), x))
        .collect(Collectors.groupingBy(x -> x.w));

      var backwardMap = backward.stream()
        .map(x -> new Meeting(x.get(backwardLength), x))
        .collect(Collectors.groupingBy(x -> x.w));

      var keys = forwardMap.keySet().stream().collect(Collectors.toSet());
      keys.retainAll(backwardMap.keySet());

      var ans = new ArrayList<List<String>>();

      // keys are meeting points
      for (var key : keys) {
        for (var backwardArr : backwardMap.get(key)) {
          for (var forwardArr : forwardMap.get(key)) {
            var item = new ArrayList<String>();

            for (var i = 0; i <= forwardLength; i++) {
              item.add(words.get(forwardArr.value.get(i)));
            }

            for (var i = backwardLength - 1; i >= 0; i--) {
              item.add(words.get(backwardArr.value.get(i)));
            }

            ans.add(item);
          }
        }
      }

      return ans;
    }

    private void dfs(int currentIndex,
                     Stack<Integer> stack,
                     ArrayList<List<Integer>> ans,
                     int path,
                     int shortest,
                     int[] visited,
                     int l,
                     HashMap<Integer, List<Integer>> adjList) {
      if (path == shortest) {
        ans.add(stack.stream().toList());
        return;
      }

      for (int i = 0; i < adjList.get(currentIndex).size(); i++) {
        var item = adjList.get(currentIndex).get(i);
        if (item == currentIndex || visited[item] == 1)
          continue;

        visited[item] = 1;
        stack.push(item);

        dfs(item, stack, ans, path + 1, shortest, visited, l, adjList);

        stack.pop();
        visited[item] = 0;
      }
    }

    private boolean oneOff(List<String> words, int w1, int w2, int l) {
      var off = 0;
      for (var i = 0; i < l; i++) {
        if (words.get(w1).charAt(i) != words.get(w2).charAt(i)) {
          off++;
          if (off > 1) {
            return false;
          }
        }
      }

      return true;
    }

    private static class Meeting {
      public Integer w;
      public List<Integer> value;

      public Meeting(Integer w, List<Integer> value) {
        this.w = w;
        this.value = value;
      }
    }

    private static class QI {
      public int index;
      public int length;

      public QI(int index, int length) {
        this.index = index;
        this.length = length;
      }
    }
  }
}