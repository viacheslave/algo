package binarysearch;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Objects;

/*
 * Problem: https://binarysearch.com/problems/Movie-Theatres
 * Submission: https://binarysearch.com/problems/Movie-Theatres/submissions/7352907
 */
public class P0226 {
  class Solution {
    public int solve(int[][] intervals) {
      var arr = new ArrayList<Item>();

      for (var i : intervals) {
        arr.add(new Item( i[0], 0 ));
        arr.add(new Item( i[1], 1 ));
      }

      arr.sort((a, b) -> {
        if (a.value == b.value)
          return b.kind - a.kind;
        return a.value - b.value;
      });

      var ans = 0;
      var current = 0;

      for (int i = 0; i < arr.size(); i++) {
        if (arr.get(i).kind == 0) {
          current++;
        }
        else {
          current--;
        }

        ans = Math.max(ans, current);
      }

      return ans;
    }

    public static class Item {
      public int value;
      public int kind;

      public Item(int value, int kind) {
        this.value = value;
        this.kind = kind;
      }
    }
  }
}