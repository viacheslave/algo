package binarysearch;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Objects;

/*
 * Problem: https://binarysearch.com/problems/Underground-Tunnel
 * Submission: https://binarysearch.com/problems/Underground-Tunnel/submissions/7583760
 */
public class P0896 {
  class UndergroundTunnel {
    private final HashMap<Integer, CheckIn> checkInHashMap = new HashMap<>();

    private final HashMap<InOut, Integer> sum = new HashMap<>();
    private final HashMap<InOut, Integer> count = new HashMap<>();

    public UndergroundTunnel() {
    }

    public void checkIn(int userId, String station, int timestamp) {
      checkInHashMap.put(userId, new CheckIn(station, timestamp));
    }

    public void checkOut(int userId, String station, int timestamp) {
      var in = checkInHashMap.get(userId);
      var key = new InOut(in.station, station);

      sum.put(key, sum.getOrDefault(key, 0) + timestamp - in.timestamp);
      count.put(key, count.getOrDefault(key, 0) + 1);
    }

    public double averageTime(String start, String end) {
      var key = new InOut(start, end);
      return 1.0 * sum.get(key) / count.get(key);
    }

    private static class InOut {
      public String in;
      public String out;

      public InOut(String in, String out) {
        this.in = in;
        this.out = out;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        InOut inOut = (InOut) o;
        return Objects.equals(in, inOut.in) && Objects.equals(out, inOut.out);
      }

      @Override
      public int hashCode() {
        return Objects.hash(in, out);
      }
    }

    private static class CheckIn {
      public String station;
      public int timestamp;

      public CheckIn(String station, int timestamp) {
        this.station = station;
        this.timestamp = timestamp;
      }
    }
  }
}