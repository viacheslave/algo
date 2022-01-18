package com.vzh.leetcode;

import java.util.*;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/delete-duplicate-folders-in-system/
 * Submission: https://leetcode.com/submissions/detail/589583028/
 */
public class P1948 {
  class Solution {
    public List<List<String>> deleteDuplicateFolder(List<List<String>> paths) {

      // create a trie structure
      var trie = new Trie();

      for (var path : paths) {
        var current = trie.root;
        for (var slice : path) {
          var node = current.add(slice);
          current = node;
        }
        current.end = true;
      }

      // mark nodes with inner paths hash-like value
      setMarkers(trie.root);

      // get set of nodes to delete
      var arr = new ArrayList<TrieNode>();
      bringAllNodes(arr, trie.root);

      var hashMap = arr.stream()
        .collect(Collectors.groupingBy(x -> x.marker, Collectors.toList()));

      var deleteSet = hashMap.entrySet().stream()
        .filter(x -> x.getValue().size() > 1)
        .map(x -> x.getKey())
        .filter(x -> !x.equals(""))
        .collect(Collectors.toSet());

      // mark nodes to delete
      deleteRecursively(deleteSet, trie.root);

      var ans = new ArrayList<List<String>>();
      var stack = new ArrayList<String>();

      // traverse the trie and get only non-remove nodes
      traverseTrie(ans, stack, trie.root);

      return ans;
    }

    private String setMarkers(TrieNode node) {
      var inners = new StringBuilder();

      for (var inner : node.nodes.entrySet())
        inners.append("(" + setMarkers(inner.getValue()) + ")");

      node.marker = inners.toString();
      return node.value + inners.toString();
    }

    private void bringAllNodes(ArrayList<TrieNode> arr, TrieNode node) {
      for (var inner : node.nodes.entrySet()) {
        arr.add(inner.getValue());
        bringAllNodes(arr, inner.getValue());
      }
    }

    private void deleteRecursively(Set<String> deleteSet, TrieNode node) {
      for (var child: node.nodes.entrySet()) {
        if (deleteSet.contains(child.getValue().marker))
          child.getValue().remove = true;
        else
          deleteRecursively(deleteSet, child.getValue());
      }
    }

    private void traverseTrie(ArrayList<List<String>> ans, List<String> list, TrieNode node) {
      for (var child : node.nodes.entrySet()) {
        if (child.getValue().remove)
          continue;

        list.add(child.getValue().value);
        ans.add(new ArrayList<>(list));

        traverseTrie(ans, list, child.getValue());

        list.remove(list.size() - 1);
      }
    }

    // Trie structure definition
    public class Trie
    {
      public TrieNode root = new TrieNode("/");
    }

    public class TrieNode
    {
      public String value;
      public String marker;
      public boolean end;
      public boolean remove;

      public TreeMap<String, TrieNode> nodes;

      public TrieNode(String value) {
        this.nodes = new TreeMap<>();
        this.value = value;
      }

      public TrieNode add(String value) {
        if (nodes.containsKey(value))
          return nodes.get(value);

        var node = new TrieNode(value);
        nodes.put(value, node);

        return node;
      }

      @Override
      public String toString() {
        return "TrieNode{" +
          "value='" + value + '\'' +
          ", marker=" + marker +
          ", nodes=" + nodes +
          '}';
      }
    }
  }
}