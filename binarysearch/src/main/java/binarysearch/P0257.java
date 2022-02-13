package binarysearch;

import java.util.*;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Dictionary-Nomad
 * Submission: https://binarysearch.com/problems/Dictionary-Nomad/submissions/7531554
 */
public class P0257 {
  class Solution {
    public int solve(String[] dictionary, String start, String end) {
      // bfs
      var words = Arrays.stream(dictionary).collect(Collectors.toSet());

      if (!words.contains(start) || !words.contains(end)) {
        return -1;
      }

      if (words.stream().map(String::length).distinct().count() > 1) {
        return -1;
      }

      var visited = new HashSet<String>();
      visited.add(start);

      var queue = new LinkedList<Word>();
      queue.add(new Word(start, 0));

      while (!queue.isEmpty()) {
        var el = queue.poll();
        if (el.word.equals(end)) {
          return el.path + 1;
        }

        for (var word : dictionary) {
          if (!visited.contains(word)) {
            if (oneOff(el.word, word)) {
              queue.offer(new Word(word, el.path + 1));
              visited.add(word);
            }
          }
        }
      }

      return -1;
    }

    private boolean oneOff(String word1, String word2) {
      var ans = 0;

      for (int i = 0; i < word1.length(); i++) {
        if (word1.charAt(i) != word2.charAt(i))
          ans++;

        if (ans > 1)
          return false;
      }

      return true;
    }

    private static class Word {
      public String word;
      public int path;

      public Word(String word, int path) {
        this.word = word;
        this.path = path;
      }
    }
  }
}