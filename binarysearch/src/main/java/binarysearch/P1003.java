package binarysearch;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Objects;
import java.util.stream.Collectors;

/*
 * Problem: https://binarysearch.com/problems/Drop-a-Ball-Down-the-Stairs
 * Submission: https://binarysearch.com/problems/Drop-a-Ball-Down-the-Stairs/submissions/8124858
 */
public class P1003 {
  class Solution {
    public int solve(int height, int[] blacklist) {
      var mod = (int)(1e9 + 7);
      var bl = new HashSet<>(Arrays.stream(blacklist).boxed().collect(Collectors.toList()));

      var dp = new HashMap<State, Integer>();
      dp.put(new State(0, height), bl.contains(height) ? 0 : 1);
      dp.put(new State(1, height), 0);

      for (var h = height - 1; h >= 0; h--) {
        if (bl.contains(h)) {
          dp.put(new State(0, h), 0);
          dp.put(new State(1, h), 0);
          continue;
        }

        // h is on even round: 0, 2, 4
        var sum = 0;
        var prev = new int[] { h + 1, h + 2, h + 4 };

        for (var p : prev) {
          if (p <= height) {
            sum += dp.get(new State(0, p));
            sum %= mod;
          }
        }

        dp.put(new State(1, h), sum);

        // h is on even round: 1, 3, 5
        sum = 0;
        prev = new int[] { h + 1, h + 3, h + 4 };

        for (var p : prev) {
          if (p <= height) {
            sum += dp.get(new State(1, p));
            sum %= mod;
          }
        }

        dp.put(new State(0, h), sum);
      }

      var ans =
        dp.get(new State(0, 0)) +
          dp.get(new State(1, 0));

      return ans % mod;
    }

    private class State {
      public int even;
      public int height;

      public State(int even, int height) {
        this.even = even;
        this.height = height;
      }

      @Override
      public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        State state = (State) o;
        return even == state.even && height == state.height;
      }

      @Override
      public int hashCode() {
        return Objects.hash(even, height);
      }

      @Override
      public String toString() {
        return "State{" +
          "even=" + even +
          ", height=" + height +
          '}';
      }
    }
  }
}