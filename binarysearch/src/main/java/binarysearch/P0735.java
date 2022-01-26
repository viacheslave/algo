package binarysearch;

import java.util.TreeMap;

/*
 * Problem: https://binarysearch.com/problems/Trie
 * Submission: https://binarysearch.com/problems/Trie/submissions/7380977
 */
public class P0735 {
  class Trie {
    TrieNode root = new TrieNode();

    public Trie() {
    }

    public void add(String s) {
      var current = root;
      for (var ch : s.toCharArray()) {
        current = current.add(ch);
      }
      current.end = true;
    }

    public boolean exists(String word) {
      var current = root;
      for (var ch : word.toCharArray()) {
        current = current.nodes[ch];
        if (current == null)
          return false;
      }
      return current.end;
    }

    public boolean startswith(String p) {
      var current = root;
      for (var ch : p.toCharArray()) {
        current = current.nodes[ch];
        if (current == null)
          return false;
      }
      return true;
    }

    private static class TrieNode {
      public boolean end;
      public TrieNode[] nodes = new TrieNode[128];

      public TrieNode add(int ch) {
        if (nodes[ch] != null)
          return nodes[ch];

        nodes[ch] = new TrieNode();
        return nodes[ch];
      }
    }
  }
}