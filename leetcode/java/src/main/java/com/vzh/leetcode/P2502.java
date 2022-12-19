package com.vzh.leetcode;

import java.util.*;

/**
 * Problem: https://leetcode.com/problems/design-memory-allocator/
 * Submission: https://leetcode.com/problems/design-memory-allocator/submissions/862121567/
 */
public class P2502 {
  class Allocator {
    private final TreeMap<Integer, Integer> available = new TreeMap<>();
    private final HashMap<Integer, List<Tuple>> taken = new HashMap<>();

    public Allocator(int n) {
      available.put(0, n - 1);
    }

    public int allocate(int size, int mID) {
      Map.Entry<Integer, Integer> entry = null;

      for (var e : available.entrySet()) {
        if (e.getValue() - e.getKey() + 1 >= size) {
          // allocate
          entry = e;
          break;
        }
      }

      if (entry == null) {
        return -1;
      }

      var takeFrom = entry.getKey();
      var takeTo = takeFrom + size - 1;

      if (takeTo < entry.getValue()) {
        available.put(takeTo + 1, entry.getValue());
      }

      available.remove(entry.getKey());

      taken.putIfAbsent(mID, new ArrayList<>());
      taken.get(mID).add(new Tuple(takeFrom, takeTo));

      return takeFrom;
    }

    public int free(int mID) {
      if (!taken.containsKey(mID)) {
        return 0;
      }

      int freed = 0;

      for (var t : taken.get(mID)) {
        var floorEntry = available.floorEntry(t.from);
        var ceilingEntry = available.ceilingEntry(t.to);

        if (floorEntry != null && ceilingEntry != null && floorEntry.getValue() + 1 == t.from && t.to + 1 == ceilingEntry.getKey()) {
          available.remove(floorEntry.getKey());
          available.remove(ceilingEntry.getKey());

          available.put(floorEntry.getKey(), ceilingEntry.getValue());
        }
        else if (floorEntry != null && floorEntry.getValue() + 1 == t.from) {
          available.remove(floorEntry.getKey());
          available.put(floorEntry.getKey(), t.to);
        }
        else if (ceilingEntry != null && t.to + 1 == ceilingEntry.getKey()) {
          available.remove(ceilingEntry.getKey());
          available.put(t.from, ceilingEntry.getValue());
        }
        else {
          available.put(t.from, t.to);
        }

        freed += t.to - t.from + 1;
      }

      taken.remove(mID);

      return freed;
    }

    class Tuple {
      private final int from;
      private final int to;

      private Tuple(int from, int to) {
        this.from = from;
        this.to = to;
      }
    }
  }
}
