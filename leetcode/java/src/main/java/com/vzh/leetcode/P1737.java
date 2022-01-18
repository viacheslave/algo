package com.vzh.leetcode;

import java.util.HashMap;

/*
 * Problem: https://leetcode.com/problems/change-minimum-characters-to-satisfy-one-of-three-conditions/
 * Submission: https://leetcode.com/submissions/detail/590953536/
 */
public class P1737 {
  class Solution {
    public int minCharacters(String a, String b) {
      var ha = new HashMap<Integer, Integer>();
      var hb = new HashMap<Integer, Integer>();

      for (var ch = 'a'; ch <= 'z'; ch++) {
        ha.put((int)ch, 0);
        hb.put((int)ch, 0);
      }

      for (int i = 0; i < a.length(); i++)
        ha.put((int)a.charAt(i), ha.get((int)a.charAt(i)) + 1);

      for (int i = 0; i < b.length(); i++)
        hb.put((int)b.charAt(i), hb.get((int)b.charAt(i)) + 1);

      // prefix sums
      var pra = new int[27];
      var prb = new int[27];

      for (var ch = 'a'; ch <= 'z'; ch++) {
        pra[ch - 97 + 1] = pra[ch - 97] + ha.get((int)ch);
        prb[ch - 97 + 1] = prb[ch - 97] + hb.get((int)ch);
      }

      var ans = Integer.MAX_VALUE;

      for (var ch = 'a'; ch <= 'z'; ch++) {
        // how many ch need to set both strings to ch
        ans = Math.min(ans, (a.length() - ha.get((int)ch)) + (b.length() - hb.get((int)ch)));


        if (ch != 'z') {
          // check characters we need to change
          var ab = a.length() - pra[ch - 97 + 1] + prb[ch - 97 + 1];
          var ba = b.length() - prb[ch - 97 + 1] + pra[ch - 97 + 1];

          ans = Math.min(ans, Math.min(ab, ba));
        }
      }

      return ans;
    }
  }
}