package leetcode;

/*
 * Problem: https://leetcode.com/problems/verify-preorder-sequence-in-binary-search-tree/
 * Submission: https://leetcode.com/submissions/detail/455527482/
 * VMWare 0-6
 */
public class P0255 {
  class Solution {
    public boolean verifyPreorder(int[] preorder) {
      return isValid(preorder, 0, preorder.length - 1);
    }

    private boolean isValid(int[] preorder, int from, int to) {
      if (to - from <= 1)
        return true;

      var root = from;
      var countLess = 0;
      var countMore = 0;
      var lessmore = 0;
      var moreless = 0;
      var mid = -1;

      for (var i = from + 1; i < to; i++) {
        if (preorder[i] < preorder[root])
          countLess++;
        if (preorder[i] > preorder[root])
          countMore++;

        if (preorder[i] < preorder[root] && preorder[root] < preorder[i + 1]) {
          lessmore++;
          mid = i;
        }

        if (preorder[i] > preorder[root] && preorder[root] > preorder[i + 1])
          return false;
      }

      if (preorder[to] < preorder[root])
        countLess++;
      if (preorder[to] > preorder[root])
        countMore++;

      if (countLess == 0 || countMore == 0)
        return isValid(preorder, from + 1, to);

      if (lessmore == 1)
        return isValid(preorder, from + 1, mid) && isValid(preorder, mid + 1, to);

      return false;
    }
  }
}