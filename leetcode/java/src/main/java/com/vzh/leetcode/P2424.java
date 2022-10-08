package com.vzh.leetcode;

import java.util.Map;
import java.util.PriorityQueue;
import java.util.TreeMap;

/**
 * Problem: https://leetcode.com/problems/longest-uploaded-prefix/
 * Submission: https://leetcode.com/problems/longest-uploaded-prefix/submissions/815909994/
 */
public class P2424 {
  class LUPrefix {

    private final TreeMap<Integer, Integer> map = new TreeMap<>();

    public LUPrefix(int n) {
    }

    public void upload(int video) {
      Map.Entry<Integer, Integer> floorEntry = map.floorEntry(video);
      Map.Entry<Integer, Integer> ceilingEntry = map.ceilingEntry(video);

      if (floorEntry != null && floorEntry.getValue() == video - 1 && ceilingEntry != null && ceilingEntry.getKey() == video + 1) {
        map.remove(floorEntry.getKey());
        map.remove(ceilingEntry.getKey());
        map.put(floorEntry.getKey(), ceilingEntry.getValue());
        return;
      }

      if (floorEntry != null && floorEntry.getValue() == video - 1) {
        map.remove(floorEntry.getKey());
        map.put(floorEntry.getKey(), video);
        return;
      }

      if (ceilingEntry != null && ceilingEntry.getKey() == video + 1) {
        map.remove(ceilingEntry.getKey());
        map.put(video, ceilingEntry.getValue());
        return;
      }

      map.put(video, video);
    }

    public int longest() {
      if (map.isEmpty()) {
        return 0;
      }

      Map.Entry<Integer, Integer> first = map.firstEntry();
      if (first.getKey() != 1) {
        return 0;
      }

      return first.getValue();
    }
  }

/**
 * Your LUPrefix object will be instantiated and called as such:
 * LUPrefix obj = new LUPrefix(n);
 * obj.upload(video);
 * int param_2 = obj.longest();
 */
}
