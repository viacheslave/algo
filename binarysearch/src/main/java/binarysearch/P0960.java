package binarysearch;

import java.util.HashMap;

/*
 * Problem: https://binarysearch.com/problems/Virtual-Boolean-Array
 * Submission: https://binarysearch.com/problems/Virtual-Boolean-Array/submissions/7161144
 */
public class P0960 {
  class BooleanArray {
    private boolean allfalse = true;
    private boolean alltrue = false;

    private HashMap<Integer, Boolean> map = new HashMap<Integer, Boolean>();

    public BooleanArray() {

    }

    public void setTrue(int i) {
      if (allfalse) {
        map.put(i, true);
      }
      else if (map.containsKey(i)) {
        map.remove(i);
      }
    }

    public void setFalse(int i) {
      if (alltrue) {
        map.put(i, true);
      }
      else if (map.containsKey(i)) {
        map.remove(i);
      }
    }

    public void setAllTrue() {
      alltrue = true;
      allfalse = false;
      map.clear();
    }

    public void setAllFalse() {
      alltrue = false;
      allfalse = true;
      map.clear();
    }

    public boolean getValue(int i) {
      if (map.containsKey(i)) {
        if (alltrue) {
          return false;
        }
        else {
          return true;
        }
      }

      if (alltrue) return true;
      return false;
    }
  }
}