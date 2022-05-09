package binarysearch;

import java.util.ArrayList;
import java.util.Map;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Upside-Down-Numbers
 * Submission: https://binarysearch.com/problems/Upside-Down-Numbers/submissions/8123485
 */
public class P0433 {
  class Solution {
    public String[] solve(int n) {
      if (n == 0) {
        return new String[0];
      }

      var sb = new StringBuilder();
      sb.append("\0".repeat(Math.max(0, n)));

      var map = Map.of(
        '0','0',
        '1','1',
        '6','9',
        '8','8',
        '9','6');

      var ans = new ArrayList<String>();

      Recursive(sb, 0, n, map, ans);

      return ans.stream().sorted().collect(Collectors.toList()).toArray(new String[0]);
    }

    private void Recursive(StringBuilder sb, int index, int limit, Map<Character, Character> map, ArrayList<String> ans) {
      if (index == (limit % 2 == 0 ? limit / 2 : limit / 2 + 1)) {
        if (sb.charAt(0) == '0' && limit > 1)
          return;

        ans.add(sb.toString());
        return;
      }

      for (var entry : map.entrySet()) {
        if (limit % 2 == 1 && index == limit / 2 && (entry.getKey() == '6' || entry.getKey() == '9'))
          continue;

        sb.setCharAt(index, entry.getKey());
        sb.setCharAt(limit - index - 1, entry.getValue());

        Recursive(sb, index + 1, limit, map, ans);
      }
    }
  }
}