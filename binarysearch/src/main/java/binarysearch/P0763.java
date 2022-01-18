package binarysearch;

import java.util.Collections;
import java.util.HashMap;
import java.util.PriorityQueue;

/*
 * Problem: https://binarysearch.com/problems/Frequency-Stack
 * Submission: https://binarysearch.com/problems/Frequency-Stack/submissions/6903354
 */
public class P0763 {
  class FrequencyStack {

    class Item implements Comparable<Item> {
      public int value;
      public int count;
      public int n;

      public Item (int value, int count, int n) {
        this.value = value;
        this.count = count;
        this.n = n;
      }

      @Override
      public int compareTo(Item o) {
        if (o.count - this.count > 0)
          return -1;
        if (o.count - this.count < 0)
          return 1;

        return this.n - o.n;
      }
    }

    private final HashMap<Integer, Integer> lastFreq = new HashMap<>();
    private final PriorityQueue<Item> pq = new PriorityQueue<>(Collections.reverseOrder());
    private int counter = 0;

    public FrequencyStack() {
    }

    public void append(int val) {
      this.lastFreq.putIfAbsent(val, 0);
      this.lastFreq.put(val, this.lastFreq.get(val) + 1);

      pq.add(new Item(val, this.lastFreq.get(val), this.counter++));
    }

    public int pop() {
      var pop = this.pq.poll();
      this.lastFreq.put(pop.value, this.lastFreq.get(pop.value) - 1);

      return pop.value;
    }
  }
}