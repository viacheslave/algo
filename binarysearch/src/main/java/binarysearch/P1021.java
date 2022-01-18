package binarysearch;

import java.util.ArrayList;
import java.util.Comparator;

/*
 * Problem: https://binarysearch.com/problems/Subtree-with-Maximum-Value
 * Submission: https://binarysearch.com/problems/Subtree-with-Maximum-Value/submissions/6910322
 */
public class P1021 {
  public int solve(Tree root) {
    if (root == null)
      return 0;

    var sums = new ArrayList<Integer>();
    traverse(root, sums);

    var max = sums.stream().max(Comparator.naturalOrder()).get();
    return Math.max(max, 0);
  }

  private int traverse(Tree node, ArrayList<Integer> sums) {
    if (node == null)
      return 0;

    var leftSum = traverse(node.left, sums);
    var rightSum = traverse(node.right, sums);

    var sum = node.val + leftSum + rightSum;
    sums.add(sum);

    return sum;
  }

  public class Tree {
    int val;
    Tree left;
    Tree right;
  }
}