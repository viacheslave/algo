package binarysearch;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;
import java.util.TreeSet;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

/*
 * Problem: https://binarysearch.com/problems/Sorting-Mail
 * Submission: https://binarysearch.com/problems/Sorting-Mail/submissions/7177117
 */
public class P0262 {
  class Solution {
    public String[] solve(String[][] mailboxes) {
      var range = IntStream.rangeClosed(0, mailboxes.length - 1)
        .boxed().collect(Collectors.toList());

      var indices = new int[mailboxes.length];
      var set = new TreeSet<>(range);
      var ans = new ArrayList<String>();

      while (!set.isEmpty()) {
        var remove = new ArrayList<Integer>();

        for (var i : set) {
          if (indices[i] < mailboxes[i].length) {
            var mail = mailboxes[i][indices[i]];
            if (!mail.equals("junk"))
              ans.add(mailboxes[i][indices[i]]);

            indices[i]++;
          }
          else {
            remove.add(i);
          }
        }

        remove.forEach(set::remove);
      }

      return ans.toArray(String[]::new);
    }
  }
}