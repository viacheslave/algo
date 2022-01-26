package binarysearch;

import binarysearch.templates.Tree;

import java.util.ArrayList;
import java.util.HashMap;

/*
 * Problem: https://binarysearch.com/problems/Tree-From-PreInorder-Traversals
 * Submission: https://binarysearch.com/problems/Tree-From-PreInorder-Traversals/submissions/7380956
 */
public class P0325 {
  class Solution {
    public Tree solve(int[] preorder, int[] inorder) {
      var inorderMap = new HashMap<Integer, Integer>();

      for (int i = 0; i < inorder.length; i++) {
        inorderMap.put(inorder[i], i);
      }

      return build(inorderMap, preorder, 0, preorder.length - 1, inorder, 0, inorder.length - 1);
    }

    private Tree build(HashMap<Integer, Integer> inorderMap, int[] preorder, int pfrom, int pto, int[] inorder, int ifrom, int ito) {
      if (pfrom > pto)
        return null;

      var index = inorderMap.get(preorder[pfrom]);
      Tree node = new Tree();
      node.val = inorder[index];

      var before = index - ifrom;

      node.left = build(inorderMap,
        preorder, pfrom + 1, pfrom + before,
        inorder, ifrom, index - 1);

      node.right = build(inorderMap,
        preorder, pfrom + before + 1, pto,
        inorder, index + 1, ito);

      return node;
    }
  }
}