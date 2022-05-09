package binarysearch;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

/*
 * Problem: https://binarysearch.com/problems/Zipped-Iterator
 * Submission: https://binarysearch.com/problems/Zipped-Iterator/submissions/8125130
 */
public class P0728 {
  class ZippedIterator {
    private final int[] a;
    private final int[] b;

    private int ia = -1;
    private int ib = -1;

    private boolean nexta = true;

    public ZippedIterator(int[] a, int[] b) {
      this.a = a;
      this.b = b;
    }

    public int next() {
      if (nexta) {
        if (ia + 1 < a.length) {
          ia++;
          nexta = false;
          return this.a[ia];
        }
      }
      else {
        if (ib + 1 < b.length) {
          ib++;
          nexta = true;
          return this.b[ib];
        }
      }

      if (ia + 1 < a.length) {
        ia++;
        return this.a[ia];
      }

      if (ib + 1 < b.length) {
        ib++;
        return this.b[ib];
      }

      return 0;
    }

    public boolean hasnext() {
      return ia + 1 < a.length || ib + 1 < b.length;
    }
  }
}