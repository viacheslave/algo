package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/List-Partitioning
 * Submission: https://binarysearch.com/problems/List-Partitioning/submissions/7323361
 */
public class P0099 {
  class Solution {
    public String[] solve(String[] strs) {
      // 3-sorting

      var low = 0;
      var mid = 0;
      var high = strs.length - 1;

      while (mid <= high) {
        var m = strs[mid];

        if (m.equals("red")) {
          swap(strs, low, mid);
          low++;
          mid++;
        }

        if (m.equals("green")) {
          mid++;
        }

        if (m.equals("blue")) {
          swap(strs, high, mid);
          high--;
        }
      }

      return strs;
    }

    private static void swap(String[] arr, int x, int y) {
      var temp = arr[x];
      arr[x] = arr[y];
      arr[y] = temp;
    }
  }
}