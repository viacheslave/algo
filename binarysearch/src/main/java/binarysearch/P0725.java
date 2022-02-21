package binarysearch;

import java.util.HashMap;

/*
 * Problem: https://binarysearch.com/problems/Least-Recently-Used-Cache
 * Submission: https://binarysearch.com/problems/Least-Recently-Used-Cache/submissions/7598735
 */
public class P0725 {
  class LRUCache {
    private final int capacity;
    private final List linkedList = new List();
    private final HashMap<Integer, Node> nodesMap = new HashMap<>();

    public LRUCache(int capacity) {
      this.capacity = capacity;
    }

    public int get(int key) {
      if (!nodesMap.containsKey(key))
        return -1;

      var value = nodesMap.get(key).val;

      var node = nodesMap.get(key);
      linkedList.remove(node);
      linkedList.addFirst(node);

      return value;
    }

    public void set(int key, int val) {
      Node node;

      if (nodesMap.containsKey(key)) {
        node = nodesMap.get(key);
        node.val = val;

        linkedList.remove(node);
        linkedList.addFirst(node);

        return;
      }

      if (linkedList.size == capacity) {
        var tail = linkedList.tail;
        linkedList.remove(tail);
        nodesMap.remove(tail.key);
      }

      node = new Node(key, val);

      linkedList.addFirst(node);
      nodesMap.put(key, node);
    }

    private static class List {
      public Node head;
      public Node tail;
      public int size;

      public void addFirst(Node node) {
        if (head != null) {
          node.next = head;
          head.prev = node;
          head = node;
        }
        else {
          head = tail = node;
        }

        size++;
      }

      public void addLast(Node node) {
        if (tail != null) {
          tail.next = node;
          node.prev = tail;
          tail = node;
        }
        else {
          head = tail = node;
        }

        size++;
      }

      public void remove(Node node) {
        if (head == tail) {
          head = tail = null;
          size--;
          return;
        }

        if (node == tail) {
          var prev = node.prev;
          prev.next = null;
          tail = prev;
        }
        else if (node == head) {
          var next = node.next;
          next.prev = null;
          head = next;
        }
        else {
          node.prev.next = node.next;
        }

        size--;
      }
    }

    private static class Node {
      public Node prev;
      public Node next;

      public int key;
      public int val;

      public Node(int key, int value) {
        this.key = key;
        this.val = value;
      }
    }
  }
}