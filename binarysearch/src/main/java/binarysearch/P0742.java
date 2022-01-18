package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Incrementable-Stack
 * Submission: https://binarysearch.com/problems/Incrementable-Stack/submissions/6656216
 */
class IncrementableStack {
  private ArrayList<Integer> arr = new ArrayList<>();

  public IncrementableStack() {
  }

  public void append(int val) {
    arr.add(val);
  }

  public int pop() {
    return arr.remove(arr.size() - 1);
  }

  public void increment(int inc, int count) {
    for (var i = 0; i < Math.min(count, arr.size()); i++)
      arr.set(i, arr.get(i) + inc);
  }
}