package binarysearch;

import java.util.*;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Fibonacci-Subset-Sum
 * Submission: https://binarysearch.com/problems/Fibonacci-Subset-Sum/submissions/8124951
 */
public class P0574 {
  class Solution {
    public int solve(int n) {
      var arr = new ArrayList<Long>();

      arr.add(1L);
      arr.add(1L);

      while (arr.get(arr.size() - 1) + arr.get(arr.size() - 2) <= Integer.MAX_VALUE) {
        arr.add(arr.get(arr.size() - 1) + arr.get(arr.size() - 2));
      }

      var treeSet = new TreeSet<Integer>();
      for (var f : arr) {
        treeSet.add(f.intValue());
      }

      var ans = 0;
      while (n > 0) {
        var value = treeSet.floor(n);
        n -= value;
        ans++;
      }

      return ans;
    }
  }
}