package binarysearch;

import binarysearch.templates.LLNode;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/IP-Address-Combinations
 * Submission: https://binarysearch.com/problems/IP-Address-Combinations/submissions/7161832
 */
public class P0202 {
  class Solution {
    public String[] solve(String ip) {
      var ans = new ArrayList<String>();

      for (var i = 1; i < ip.length(); i++) {
        var s1 = ip.substring(0, i);
        if (!fits(s1))
          continue;

        for (var j = i + 1; j < ip.length(); j++) {

          var s2 = ip.substring(i, j);
          if (!fits(s2))
            continue;

          for (var k = j + 1; k < ip.length(); k++) {

            var s3 = ip.substring(j, k);
            if (!fits(s3))
              continue;

            var s4 = ip.substring(k);
            if (!fits(s4))
              continue;

            ans.add(s1 + '.' + s2 + '.' + s3 + '.' + s4);
          }
        }
      }

      return ans.stream().toArray(String[]::new);
    }

    private boolean fits(String s1) {
      if (s1.equals("0"))
        return true;

      if (s1.length() > 3 || s1.charAt(0) == '0' || Integer.parseInt(s1) > 255)
        return false;

      return true;
    }
  }
}