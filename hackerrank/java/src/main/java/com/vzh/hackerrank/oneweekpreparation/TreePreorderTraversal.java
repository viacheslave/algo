package com.vzh.hackerrank.oneweekpreparation;

import java.util.*;
import java.io.*;

public class TreePreorderTraversal {
  static class Node {
    Node left;
    Node right;
    int data;

    Node(int data) {
      this.data = data;
      left = null;
      right = null;
    }
  }

  class Solution {

    /* you only have to complete the function given below.
    Node is defined as

    class Node {
        int data;
        Node left;
        Node right;
    }

    */

    public static void preOrder(Node root) {
      ArrayList<Integer> arr = new ArrayList<Integer>();

      traverse(root, arr);

      for (int i = 0; i < arr.size(); i++) {
        if (i != 0) {
          System.out.print(' ');
        }
        System.out.print(arr.get(i));
      }
    }

    private static void traverse(Node node, ArrayList<Integer> arr) {
      if (node == null)
        return;

      arr.add(node.data);

      traverse(node.left, arr);
      traverse(node.right, arr);
    }

    public static Node insert(Node root, int data) {
      if (root == null) {
        return new Node(data);
      } else {
        Node cur;
        if (data <= root.data) {
          cur = insert(root.left, data);
          root.left = cur;
        } else {
          cur = insert(root.right, data);
          root.right = cur;
        }
        return root;
      }
    }
    /*
    public static void main(String[] args) {
      Scanner scan = new Scanner(System.in);
      int t = scan.nextInt();
      Node root = null;
      while (t-- > 0) {
        int data = scan.nextInt();
        root = insert(root, data);
      }
      scan.close();
      preOrder(root);
    }
    */
  }
}
