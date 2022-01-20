package binarysearch;

/*
 * Problem: https://binarysearch.com/problems/Long-Distance
 * Submission: https://binarysearch.com/problems/Long-Distance/submissions/7334497
 */
public class P0162 {
  class Solution {
    public int[] solve(int[] lst) {
      if (lst.length == 0)
        return new int[0];

      var arr = new int[lst.length];

      var ind = new int[lst.length];
      for (var i = 0; i < ind.length; i++)
        ind[i] = i;

      calculate(lst, 0, lst.length - 1, arr, ind);
      return arr;
    }

    private static void calculate(int[] q, int from, int to, int[] arr, int[] ind) {
      if (from == to)
        return;

      var mid = (from + to) >> 1;

      calculate(q, from, mid, arr, ind);
      calculate(q, mid + 1, to, arr, ind);

      // merge
      var ax = new int[to - from + 1];
      var i = from;
      var j = mid + 1;
      var k = 0;

      var itt = new int[to - from + 1];

      while (i <= mid && j <= to) {
        if (q[i] <= q[j]) {
          ax[k] = q[i];
          itt[k] = ind[i];

          arr[ind[i]] += j - (mid + 1);

          i++; k++;
        }
        else {
          ax[k] = q[j];
          itt[k] = ind[j];

          j++; k++;
        }
      }

      while (i <= mid) {
        ax[k] = q[i];
        itt[k] = ind[i];

        arr[ind[i]] += (to - mid);

        i++; k++;
      }

      while (j <= to) {
        ax[k] = q[j];
        itt[k] = ind[j];

        j++; k++;
      }

      for (var a = 0; a < ax.length; a++) {
        q[from + a] = ax[a];
        ind[from + a] = itt[a];
      }
    }
  }
}