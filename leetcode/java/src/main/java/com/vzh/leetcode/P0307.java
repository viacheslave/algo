package com.vzh.leetcode;

import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/range-sum-query-mutable/
 * Submission: https://leetcode.com/submissions/detail/761289879/
 */
class P0307 {
  class NumArray {
    private final SegmentTree _tree;

    public NumArray(int[] nums) {
      _tree = new SegmentTree(nums);
    }

    public void update(int index, int val) {
      _tree.update(index, val);
    }

    public int sumRange(int left, int right) {
      return _tree.sum(left, right);
    }

    public static class SegmentTree {
      private final int[] tree;
      private final int length;

      /**
       * Constructs new Segment Tree
       *
       * @param src source array
       */
      public SegmentTree(int[] src) {
        length = src.length;
        tree = new int[4 * length];
        buildTree(src, 1, 0, length - 1);
      }

      /**
       * Calculates sum in range [from, to]
       *
       * @param from range index from
       * @param to   range index to
       * @return     sum of values in range
       */
      public int sum(int from, int to) {
        return sum(1, 0, length - 1, from, to);
      }

      /**
       * Updates element at index
       *
       * @param i     element index
       * @param value new value
       */
      public void update(int i, int value) {
        update(1, 0, length - 1, i, value);
      }

      private int sum(int index, int low, int high, int from, int to) {
        if (from > to)
          return 0;

        if (low == from && high == to) {
          return tree[index];
        }
        else {
          var mid = (low + high) >> 1;
          var left = sum(index * 2, low, mid, from, Math.min(mid, to));
          var right = sum(index * 2 + 1, mid + 1, high, Math.max(mid + 1, from), to);
          return left + right;
        }
      }

      private void update(int index, int low, int high, int i, int value) {
        if (low == high) {
          tree[index] = value;
        }
        else {
          var mid = (low + high) >> 1;
          if (i <= mid) {
            update(index * 2, low, mid, i, value);
          }
          else {
            update(index * 2 + 1, mid + 1, high, i, value);
          }
          tree[index] = tree[index * 2] + tree[index * 2 + 1];
        }
      }

      private void buildTree(int[] src, int index, int low, int high) {
        if (low == high) {
          tree[index] = src[low];
        }
        else {
          var mid = (low + high) >> 1;
          buildTree(src, index * 2, low, mid);
          buildTree(src, index * 2 + 1, mid + 1, high);
          tree[index] = tree[index * 2] + tree[index * 2 + 1];
        }
      }
    }
  }
}