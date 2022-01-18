package com.vzh.leetcode;

import java.util.*;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/minimum-number-of-people-to-teach/
 * Submission: https://leetcode.com/submissions/detail/588164323/
 */
public class P1733 {
  class Solution {
    public int minimumTeachings(int n, int[][] languages, int[][] friendships) {
      var people = new HashMap<Integer, Set<Integer>>();

      for (var i = 0; i < languages.length; i++) {
        people.put(i + 1, Arrays.stream(languages[i]).boxed().collect(Collectors.toSet()));
      }

      // filter friend pairs who cannot communicate
      var fss = new ArrayList<int[]>();
      for (var fs : friendships) {
        var intersection = new HashSet<Integer>(people.get(fs[0]));
        intersection.retainAll(people.get(fs[1]));

        if (intersection.size() == 0)
          fss.add(fs);
      }

      var ans = Integer.MAX_VALUE;

      // pick language
      // iterate through friend pairs, check parties we need to teach
      for (int i = 1; i <= n; i++) {
        var teachPeople = new int[languages.length + 1];

        for (var friend : fss) {
          if (!people.get(friend[0]).contains(i))
            teachPeople[friend[0]]++;
          if (!people.get(friend[1]).contains(i))
            teachPeople[friend[1]]++;
        }

        var teach = Arrays.stream(teachPeople).boxed().filter(x -> x > 0).count();
        ans = Math.min(ans, (int)teach);
      }

      return ans;
    }
  }
}