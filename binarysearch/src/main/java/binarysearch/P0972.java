package binarysearch;

import java.util.ArrayList;

/*
 * Problem: https://binarysearch.com/problems/Virtually-Cloneable-Stacks
 * Submission: https://binarysearch.com/problems/Virtually-Cloneable-Stacks/submissions/7457422
 */
class P0972 {
  class VirtuallyCloneableStacks {
    private ArrayList<Integer> arr = new ArrayList<>();

    public VirtuallyCloneableStacks() {
      arr.add(0);
    }

    public void copyPush(int i) {
      var num = arr.get(i);
      arr.add(num + 1);
    }

    public void copyPop(int i) {
      var num = arr.get(i);
      arr.add(num - 1);
    }

    public int size(int i) {
      return arr.get(i);
    }
  }
}