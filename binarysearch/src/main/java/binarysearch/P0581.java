package binarysearch;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

/*
 * Problem: https://binarysearch.com/problems/Word-Concatenation
 * Submission: https://binarysearch.com/problems/Word-Concatenation/submissions/7380181
 */
public class P0581 {
  class Solution {
    public int solve(String[] words) {
      Arrays.sort(words);

      TrieNode root = new TrieNode();

      for (String word: words) {
        TrieNode current = root;
        for (var ch: word.toCharArray()) {
          current = current.add(ch - 'a');
        }
        current.end = true;
      }

      Set<String> ans = new HashSet<>();

      for (String word: words) {
        if (dfs(word, 0, root, ans)) {
          ans.add(word);
        }
      }

      return ans.size();
    }

    private boolean dfs(String word, int start, TrieNode root, Set<String> ans) {
      if (ans.contains(word.substring(start))) {
        return true;
      }

      TrieNode current = root;

      for (int i = start; i < word.length(); i++) {
        current = current.nodes[word.charAt(i) - 'a'];
        if (current == null)
          break;

        if (current.end) {
          if (i == word.length() - 1) {
            // exclude the word itself
            return start > 0;
          }

          boolean result = dfs(word, i + 1, root, ans);
          if (result)
            // return early
            return true;
        }
      }

      return false;
    }

    private static class TrieNode {
      public boolean end;
      public int ch;
      public TrieNode[] nodes = new TrieNode[26];

      public TrieNode add(int ch) {
        if (nodes[ch] != null)
          return nodes[ch];

        nodes[ch] = new TrieNode();
        nodes[ch].ch = ch;
        return nodes[ch];
      }
    }
  }
}