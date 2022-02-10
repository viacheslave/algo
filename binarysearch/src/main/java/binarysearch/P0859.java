package binarysearch;

import java.util.*;

/*
 * Problem: https://binarysearch.com/problems/Earliest-Uniques-in-a-Stream
 * Submission: https://binarysearch.com/problems/Earliest-Uniques-in-a-Stream/submissions/7508062
 */
public class P0859 {
  class EarliestUnique {
    private final HashMap<Integer, Node> map = new HashMap<>();
    private Node head = null;
    private Node tail = null;

    public EarliestUnique(int[] nums) {
      for (var num : nums)
        add(num);
    }

    public void add(int num) {
      if (map.containsKey(num)) {
        var node = map.get(num);
        map.remove(num);

        remove(node);
      }
      else {
        var node = new Node(num);
        map.put(num, node);

        append(node);
      }
    }

    private void append(Node node) {
      if (head == null) {
        head = node;
        tail = node;
        return;
      }

      node.prev = tail;
      tail.next = node;
      tail = tail.next;
    }

    private void remove(Node node) {
      if (head == tail) {
        head = tail = null;
        return;
      }

      if (node == head) {
        head = head.next;

        if (head != null)
          head.prev = null;
      }

      else if (node == tail) {
        tail = tail.prev;

        if (tail != null)
          tail.next = null;
      }
      else {
        if (node.prev != null)
          node.prev.next = node.next;
      }
    }

    public int earliestUnique() {
      return head != null ? head.val : -1;
    }

    private static class Node {
      public int val;
      public Node prev;
      public Node next;

      public Node(int val) {
        this.val = val;
      }
    }
  }
}