package binarysearch;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.Objects;

/*
 * Problem: https://binarysearch.com/problems/Max-XOR-of-Two-Integers
 * Submission: https://binarysearch.com/problems/Max-XOR-of-Two-Integers/submissions/7412574
 */
public class P0821 {
  class Solution {
    public int solve(int[] nums) {
      var root = new TrieNode();

      // build trie
      for (var n : nums) {
        var current = root;

        for (var i = 30; i >= 0; i--) {
          var v = n >> i;

          if (v % 2 == 0) {
            if (current.left == null)
              current.left = new TrieNode();
            current = current.left;
          }
          else {
            if (current.right == null)
              current.right = new TrieNode();
            current = current.right;
          }
        }
      }

      var ans = 0;

      for (var n : nums) {
        var current = root;
        var value = 0;

        for (var i = 30; i >= 0; i--) {
          var v = n >> i;

          if (v % 2 == 0) {
            if (current.right != null) {
              current = current.right;
              value += 1 << i;
            }
            else {
              current = current.left;
            }
          }
          else {
            if (current.left != null) {
              current = current.left;
              value += 1 << i;
            }
            else {
              current = current.right;
            }
          }
        }

        ans = Math.max(ans, value);
      }

      return ans;
    }

    private static class TrieNode {
      public TrieNode left;
      public TrieNode right;
    }
  }
}