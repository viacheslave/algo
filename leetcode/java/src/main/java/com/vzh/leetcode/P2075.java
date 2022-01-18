package com.vzh.leetcode;

import java.util.Arrays;

/*
 * Problem: https://leetcode.com/problems/decode-the-slanted-ciphertext/
 * Submission: https://leetcode.com/submissions/detail/586947137/
 */
public class P2075 {
  public class Solution {
    public String decodeCiphertext(String encodedText, int rows) {
      var sb = new StringBuilder();

      var row = 0;
      var col = 0;
      var startcol = 0;
      var cols = encodedText.length() / rows;

      while (true) {
        if (row == 0 && col == cols)
          break;

        sb.append(encodedText.charAt(row * cols + col));

        row++;
        col++;

        if (row == rows || col == cols) {
          startcol++;
          row = 0;
          col = startcol;
        }
      }

      return sb.toString().stripTrailing();
    }
  }
}