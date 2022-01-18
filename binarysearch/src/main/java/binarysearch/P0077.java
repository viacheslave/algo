package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Stack;

/*
 * Problem: https://binarysearch.com/problems/Anagram-Partitioning
 * Submission: https://binarysearch.com/problems/Anagram-Partitioning/submissions/7314816
 */
public class P0077 {
  class Solution {
    public int[] solve(String a, String b) {
      var ans = new ArrayList<Integer>();

      var freq_a = new int[26];
      var freq_b = new int[26];

      var length = 0;

      for (int i = 0; i < a.length(); i++) {
        var ai = a.charAt(i) - 97;
        var bi = b.charAt(i) - 97;

        freq_a[ai]++;
        freq_b[bi]++;

        length++;

        if (eq(freq_a, freq_b)) {
          ans.add(i - length + 1);
          length = 0;
          Arrays.fill(freq_a, 0);
          Arrays.fill(freq_b, 0);

          if (i == a.length() - 1)
            return ans.stream().mapToInt(x -> x).toArray();
        }
      }

      return new int[0];
    }

    private boolean eq(int[] freq_a, int[] freq_b) {
      for (int i = 0; i < 26; i++) {
        if (freq_a[i] != freq_b[i])
          return false;
      }
      return true;
    }
  }
}