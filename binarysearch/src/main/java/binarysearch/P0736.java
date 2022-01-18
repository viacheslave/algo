package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Hit-Counter
 * Submission: https://binarysearch.com/problems/Hit-Counter/submissions/7295229
 */
public class P0736 {
  class HitCounter {
    private ArrayList<Integer> arr = new ArrayList<>();

    public HitCounter() {
    }

    public void add(int timestamp) {
      arr.add(timestamp);
    }

    public int count(int timestamp) {
      var ts = timestamp - 60;

      if (arr.size() == 0)
        return 0;

      if (ts <= arr.get(0))
        return arr.size();

      if (ts > arr.get(arr.size() - 1))
        return 0;

      // binary search
      var left = 0;
      var right = arr.size() - 1;

      while (true) {
        if (right - left <= 1) {
          if (ts <= arr.get(left))
            return arr.size() - left;
          return arr.size() - right;
        }

        var mid = (left + right) >> 1;
        if (ts <= arr.get(mid))
          right = mid;
        else
          left = mid;
      }
    }
  }
}