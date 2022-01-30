package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;

/*
 * Problem: https://binarysearch.com/problems/Longest-Prefix-Sequence
 * Submission: https://binarysearch.com/problems/Longest-Prefix-Sequence/submissions/7414701
 */
public class P1027 {
  class Solution {
    public int solve(String[] words) {
      var root = new Trie();

      for (var word : words) {
        var cursor = root;
        for (var ch : word.toCharArray()) {
          cursor = cursor.add(ch - 'a');
        }
        cursor.end = true;
      }

      var startNodes = new ArrayList<Trie>();
      findStartNodes(root, startNodes);

      var ans = Integer.MIN_VALUE;
      for (var node : startNodes) {
        ans = Math.max(ans, dfs(node, 1));
      }

      return ans;
    }

    private int dfs(Trie node, int length) {
      var max = length;

      for (var i = 0; i < 26; i++) {
        if (node.nodes[i] != null) {
          if (node.nodes[i].end) {
            max = Math.max(max, dfs(node.nodes[i], length + 1));
          }
        }
      }

      return max;
    }

    private void findStartNodes(Trie node, ArrayList<Trie> startNodes) {
      if (node.end) {
        startNodes.add(node);
        return;
      }

      for (var i = 0; i < 26; i++) {
        if (node.nodes[i] != null) {
          findStartNodes(node.nodes[i], startNodes);
        }
      }
    }

    private static class Trie {
      public Trie[] nodes = new Trie[26];
      public boolean end;

      public Trie add(int ch) {
        if (nodes[ch] != null)
          return nodes[ch];

        nodes[ch] = new Trie();
        return nodes[ch];
      }
    }
  }
}